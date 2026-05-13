using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.Enums
{
    public enum ItemType
    {
        Stocked = 1,      // صنف مخزني (له كمية وجرد)
        Service = 2,      // خدمة (مثل مصاريف الشحن أو الاستشارات)
        Consumable = 3    // مستهلكات (تُشترى وتُصرف مباشرة ولا تدخل في قيمة المخزون)
    }
}
