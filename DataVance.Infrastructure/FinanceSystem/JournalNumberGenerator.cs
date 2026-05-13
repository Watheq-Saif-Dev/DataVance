using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.FinanceSystem
{
    public class JournalNumberGenerator : IJournalNumberGenerator
    {
        private readonly IApplicationDbContext _context;

        public JournalNumberGenerator(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateNextNumberAsync(CancellationToken ct = default)
        {
            // „À«· ·· —ﬁÌ„: JE-2026-0001
            var year = DateTime.UtcNow.Year;
            var prefix = $"JE-{year}-";

            // Ã·» ¬Œ— —ﬁ„  „ «” Œœ«„Â ·Â–Â «·”‰…
            var lastNumber = await _context.JournalEntries
                .Where(x => x.EntryNumber.StartsWith(prefix))
                .OrderByDescending(x => x.EntryNumber)
                .Select(x => x.EntryNumber)
                .FirstOrDefaultAsync(ct);

            if (string.IsNullOrEmpty(lastNumber))
            {
                return $"{prefix}0001";
            }

            // «” Œ—«Ã «·Ã“¡ «·—ﬁ„Ì Ê“Ì«œ Â
            var lastSequencePart = lastNumber.Replace(prefix, "");
            if (int.TryParse(lastSequencePart, out int lastSequence))
            {
                return $"{prefix}{(lastSequence + 1).ToString("D4")}";
            }

            return $"{prefix}{Guid.NewGuid().ToString().Substring(0, 4)}"; // fallback
        }
    }
}
