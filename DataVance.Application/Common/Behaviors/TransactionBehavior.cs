using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationDbContext _context;
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        public TransactionBehavior(
                IUnitOfWork unitOfWork,
                IApplicationDbContext context,
                ILogger<TransactionBehavior<TRequest, TResponse>> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            var requestName = typeof(TRequest).Name;
            if (!requestName.EndsWith("Command"))
            {
                return await next();
            }
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                try
                {
                    if (!_unitOfWork.HasActiveTransaction)
                    {
                        _logger.LogInformation("?? ط¨ط¯ط، طھط±ط§ظ†ط²ظƒط´ظ† ط¬ط¯ظٹط¯ ظ„ظ„ط¹ظ…ظ„ظٹط© {CommandName}", requestName);
                        await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, ct);
                    }

                    var response = await next();

                    if (_unitOfWork.HasActiveTransaction)
                    {
                        await _unitOfWork.CommitAsync(ct);
                        _logger.LogInformation("? طھظ… طھط£ظƒظٹط¯ ط§ظ„طھط±ط§ظ†ط²ظƒط´ظ† (Commit) ط¨ظ†ط¬ط§ط­ ظ„ظ„ط¹ظ…ظ„ظٹط© {CommandName}", requestName);
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "? ط®ط·ط£ ط­ط±ط¬ ط£ط«ظ†ط§ط، ظ…ط¹ط§ظ„ط¬ط© {CommandName}. ط³ظٹطھظ… ط§ظ„طھط±ط§ط¬ط¹ (Rollback) ظپظˆط±ط§ظ‹.", requestName);
                    if (_unitOfWork.HasActiveTransaction)
                    {
                        await _unitOfWork.RollbackAsync(ct);
                    }
                    throw;
                }


            });
        }
    }
}


