using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Currencies.Commands;
using DataVance.Domain.Common;
using MediatR;

namespace DataVance.Application.Features.Currencies.Handlers
{
    public class UpdateExchangeRateCommandHandler : IRequestHandler<UpdateExchangeRateCommand, bool>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public UpdateExchangeRateCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork, IExchangeRateRepository exchangeRateRepository)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<bool> Handle(UpdateExchangeRateCommand request, CancellationToken ct)
        {
            var currency = await _currencyRepository.GetByIdAsync(request.CurrencyId, ct);

            if (currency == null) throw new KeyNotFoundException();

            currency.UpdateRate(request.NewRate, request.EffectiveDate);



            return true;

        }
    }
}


