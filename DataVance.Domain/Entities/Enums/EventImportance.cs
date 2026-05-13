using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.Enums
{
    public enum EventImportance
    {
        Critical = 1,  // فشل الحدث = فشل العملية
        Optional = 2   // فشل الحدث = تجاهل فقط
    }
}
