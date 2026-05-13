using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Shared.Enums
{
    public enum JournalEntryType
    {
        Standard = 1,
        OpeningBalance = 2 // هذا النوع لا يتكرر إلا مرة واحدة في السنة المالية
    }
}
