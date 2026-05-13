using System;
using System.Linq.Expressions;
using DataVance.Domain.Finance.Journal.Entities;
using DataVance.Domain.Finance.Shared.Enums;

namespace DataVance.Application.Features.RuleEngine.Specifications
{
    public class UnpostedJournalEntriesSpec
    {
        public Guid FiscalYearId { get; }
        public Guid BranchId { get; }

        public UnpostedJournalEntriesSpec(Guid fiscalYearId, Guid branchId)
        {
            FiscalYearId = fiscalYearId;
            BranchId = branchId;
        }

        public Expression<Func<JournalEntry, bool>> ToExpression()
        {
            return x => x.FiscalYearId == FiscalYearId 
                     && x.BranchId == BranchId 
                     && x.Status != JournalStatus.Posted;
        }
    }
}
