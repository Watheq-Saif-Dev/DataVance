using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.Currencies.Commands;
using DataVance.Domain.Common;
using DataVance.Domain.Finance.Currencies.Entities;
using MediatR;
namespace DataVance.Application.Features.Currencies.Handlers
{
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Guid>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCurrencyCommandHandler(
            ICurrencyRepository currencyRepository,
            IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            if (request.IsBaseCurrency && await _currencyRepository.AnyBaseCurrencyExistsAsync(cancellationToken))
            {
                throw new InvalidOperationException("النظام يحتوي بالفعل على عملة أساسية. لا يمكن إضافة عملة أساسية أخرى.");
            }
            if (!await _currencyRepository.IsCodeUniqueAsync(request.Code, cancellationToken))
            {
                throw new InvalidOperationException($"رمز العملة {request.Code} موجود مسبقاً.");
            }
            var currency = Currency.Create(
                request.Code,
                request.Name,
                request.Symbol,
                request.DecimalPlaces,
                request.IsBaseCurrency,
                request.InitialExchangeRate
                );
            await _currencyRepository.AddAsync(currency, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return currency.Id;
        }
    }
}


