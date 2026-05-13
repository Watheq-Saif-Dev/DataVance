using DataVance.Application.Common.Interfaces;
using DataVance.Application.Security.Service;
using DataVance.Domain.Common;
using DataVance.Domain.Entities.EventSystem;
using DataVance.Infrastructure.Common;
using DataVance.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.EventManagement.BackgroundServices
{
    public class OutboxProcessor : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<OutboxProcessor> _logger;


        public OutboxProcessor(IServiceScopeFactory scopeFactory, ILogger<OutboxProcessor> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Outbox worker started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                int processedCount = 0; // ظ…طھط؛ظٹط± ظ„ظ…ط±ط§ظ‚ط¨ط© ط¹ط¯ط¯ ط§ظ„ط±ط³ط§ط¦ظ„ ط§ظ„ظ…ط¹ط§ظ„ط¬ط©

                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                    var eventExecutor = scope.ServiceProvider.GetRequiredService<IOperationEventExecutor>();

                    var thresholdTime = DateTime.UtcNow.AddSeconds(-2);

                    var messages = await context.OutboxMessages
                        .Where(m => !m.Processed && m.RetryCount < 3 && m.OccurredOnUtc <= thresholdTime)
                        .OrderBy(m => m.OccurredOnUtc)
                        .Take(20)
                        .ToListAsync(stoppingToken);

                    processedCount = messages.Count;

                    if (processedCount > 0)
                    {
                        _logger.LogInformation("ًں”ژ Found {Count} outbox messages to process.", processedCount);
                        foreach (var message in messages)
                        {
                            try
                            {
                                await unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, stoppingToken);

                                bool success = false;
                                if (message.TargetType == OutboxTargetType.Operation)
                                {
                                    await eventExecutor.GenerateEventsFromOperation(message);
                                    success = true; // طھظˆظ„ظٹط¯ ط§ظ„ط£ط­ط¯ط§ط« ظٹط¹طھط¨ط± ط¹ظ…ظ„ظٹط© ظ†ط§ط¬ط­ط©
                                }
                                else if (message.TargetType == OutboxTargetType.Event)
                                {
                                    // ظ†ط¹ط¯ظ„ ط§ظ„ط¯ط§ظ„ط© ظ„طھط¹ظٹط¯ ظ‚ظٹظ…ط© ط¨ظˆظ„ظٹظ† طھظˆط¶ط­ ظ†ط¬ط§ط­ ط§ظ„طھظ†ظپظٹط°/ط§ظ„طµظ„ط§ط­ظٹط©
                                    success = await eventExecutor.ExecuteSpecificEvent(message);

                                }

                                if (success)
                                {
                                    message.MarkAsProcessed();
                                    await unitOfWork.CommitAsync(stoppingToken);
                                }
                                else
                                {
                                    // ط¥ط°ط§ ظپط´ظ„ ط§ظ„ظ…ظ†ط·ظ‚ (ظ…ط«ظ„ ط§ظ„طµظ„ط§ط­ظٹط§طھ)طŒ ظ†ظ„ط؛ظٹ ط§ظ„طھط±ط§ظ†ط²ظƒط´ظ†
                                    await unitOfWork.RollbackAsync(stoppingToken);
                                    await context.SaveChangesAsync(stoppingToken);
                                }
                            }
                            catch (Exception ex)
                            {
                                await unitOfWork.RollbackAsync(stoppingToken);

                                message.SetError(ex.Message);
                                message.RetryCount++;
                                await context.SaveChangesAsync(stoppingToken);

                                _logger.LogError(ex, "ظپط´ظ„ ظپظٹ ظ…ط¹ط§ظ„ط¬ط© ط§ظ„ط±ط³ط§ظ„ط© {Id}", message.Id);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, " Critical failure in Outbox processing cycle.");
                }

            }
        }
    }
}
