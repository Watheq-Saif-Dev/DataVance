using DataVance.Application.Features.FinancialReports.DTOs;
using MediatR;
namespace DataVance.Application.Features.FinancialReports.Queries
{
    public record GetTrialBalanceQuery(
    Guid BranchId,
    Guid FiscalYearId,
    DateTime FromDate,
    DateTime ToDate) : IRequest<List<TrialBalanceDto>>;
}

