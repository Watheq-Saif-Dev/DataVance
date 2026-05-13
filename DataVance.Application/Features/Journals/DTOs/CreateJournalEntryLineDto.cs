using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.FinanceSystem.DTO
{
    public record CreateJournalEntryLineDto(
      Guid AccountId,
      decimal Debit,
      decimal Credit,
      Guid? CostCenterId,
      string Description
  );
}
