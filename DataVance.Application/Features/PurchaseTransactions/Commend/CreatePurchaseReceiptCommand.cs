using DataVance.Application.Features.PurchaseTransactions.DTO;
using DataVance.Domain.Finance.PaymentMethods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.PurchaseTransactions.Commend
{



    public record CreatePurchaseReceiptCommand(
    string ReceiptNo,
    PaymentMethodType PaymentMethod,
    Guid? FinancialAccountId,
    string? FinancialAccountName,
    string? PaymentReferenceNo,
    Guid VendorId,
    Guid BranchId,
    Guid UserId,
    Guid CurrencyId,
    decimal ExchangeRate,
    string CurrCode,
    Guid warehouseId,
    decimal HeaderDiscount,
    List<ReceiptItemDto> Items) : IRequest<bool>;


}



