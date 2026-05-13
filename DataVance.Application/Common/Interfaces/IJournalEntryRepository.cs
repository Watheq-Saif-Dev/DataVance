using DataVance.Domain.Finance.Journal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Common.Interfaces
{
    public interface IJournalEntryRepository
    {
        Task AddAsync(JournalEntry entry, CancellationToken ct = default);
        Task DeleteAsync(JournalEntry entry);
        Task<JournalEntry?> GetByIdAsync(Guid id);
        Task<JournalEntry?> GetByIdWithLinesAsync(Guid id);
    }
}
