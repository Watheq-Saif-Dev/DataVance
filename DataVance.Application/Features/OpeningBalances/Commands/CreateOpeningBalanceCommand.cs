using DataVance.Application.Features.OpeningBalances.DTOs;
using DataVance.Domain.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.OpeningBalances.Commands
{

    public class CreateOpeningBalanceCommand : IRequest<Guid>
    {
        public DateTime OpeningDate { get; set; }
        public required Guid BranchId { get; set; }
        public Guid CurrencyId { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string? Description { get; set; }
        public List<OpeningBalanceLineDto> Lines { get; set; } = new();
        public decimal TotalDebit => Lines.Sum(l => l.Debit);
        public decimal TotalCredit => Lines.Sum(l => l.Credit);
        public bool IsBalanced => Math.Abs(Lines.Sum(x => x.Debit) - Lines.Sum(x => x.Credit)) <= 0.0001m;
    }


}


