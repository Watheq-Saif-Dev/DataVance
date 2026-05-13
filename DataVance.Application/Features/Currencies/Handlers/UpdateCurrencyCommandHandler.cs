using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Currencies.Commands;
using DataVance.Domain.Common;
using MediatR;

namespace DataVance.Application.Features.Currencies.Handlers
{
    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, bool>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCurrencyCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _currencyRepository.GetByIdAsync(request.Id, cancellationToken);
            if (currency == null) return false;
            currency.UpdateDetails(request.Name, request.Symbol, request.DecimalPlaces, request.IsActive);
            if (currency.CurrentExchangeRate != request.NewRate)
            {
                currency.UpdateRate(request.NewRate, DateTime.Now);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}


