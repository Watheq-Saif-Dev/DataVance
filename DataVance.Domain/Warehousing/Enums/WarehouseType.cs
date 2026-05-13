using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Warehousing.Enums
{
    public enum WarehouseType
    {
        Physical = 1,  // مخزن حقيقي (مثل: مستودع المنصورة)
        Transit = 2,   // مخزن وسيط (بضاعة في الطريق)
        Virtual = 3,   // مخزن افتراضي (للتسويات، التوالف، أو بضاعة الأمانات)
    }
}

