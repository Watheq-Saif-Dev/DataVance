using DataVance.Domain.Finance.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.DTO.JournalDTO
{
    public record JournalReviewDto
    {
        public Guid Id { get; init; }
        public string EntryNumber { get; init; } = string.Empty;
        public DateTime EntryDate { get; init; }
        public string Description { get; init; } = string.Empty;
        public JournalStatus Status { get; init; }
        public string? CreatedBy { get; init; } = string.Empty;
        public string CurrencyCode { get; init; } = string.Empty;
        public decimal TotalDebitLocal { get; init; }
        public decimal TotalCreditLocal { get; init; }
        public bool IsBalanced => Math.Abs(TotalDebitLocal - TotalCreditLocal) < 0.001m;

    }
}

