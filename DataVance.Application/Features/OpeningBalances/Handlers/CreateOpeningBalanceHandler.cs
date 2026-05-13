using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.OpeningBalances.Commands;
using DataVance.Application.SharedAgg.Setting.Interface;
using DataVance.Domain.Common;
using DataVance.Domain.Common.Models;
using DataVance.Domain.Finance.OpeningBalances.Entities;
using DataVance.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.Handlers
{

    public class CreateOpeningBalanceCommandHandler : IRequestHandler<CreateOpeningBalanceCommand, Guid>
    {
        private readonly IOpeningBalanceRepository _repository;
        private readonly IUnitOfWork _uow;
        private readonly ISystemSettingsService _settingsService;

        public CreateOpeningBalanceCommandHandler(
            IOpeningBalanceRepository repository,
            IUnitOfWork uow,
            ISystemSettingsService settingsService)
        {
            _repository = repository;
            _uow = uow;
            _settingsService = settingsService;
        }

        public async Task<Guid> Handle(CreateOpeningBalanceCommand request, CancellationToken cancellationToken)
        {
            var suspenseAccIdStr = await _settingsService.GetSettingValueAsync("OB_SuspenseAccount");
            Guid? suspenseAccountId = !string.IsNullOrEmpty(suspenseAccIdStr)
                                       ? Guid.Parse(suspenseAccIdStr)
                                       : null;
            var openingBalance = new OpeningBalance(
                request.OpeningDate,
                request.BranchId,
                request.CurrencyId,
                request.CurrencyCode,
                request.ExchangeRate
            );


            foreach (var line in request.Lines)
            {
                openingBalance.AddLine(line.AccountId, line.Debit, line.Credit);
            }
            if (suspenseAccountId.HasValue)
            {
                openingBalance.BalanceWithSuspenseAccount(suspenseAccountId.Value);
            }
            else
            {
                openingBalance.EnsureBalanced();
            }
            await _repository.AddAsync(openingBalance);
            await _uow.SaveChangesAsync(cancellationToken);

            return openingBalance.Id;
        }
    }
}




