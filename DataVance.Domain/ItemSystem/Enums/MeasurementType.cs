using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.Enums
{
    public enum MeasurementType
    {
        Quantity = 1, // كميات وأعداد (حبة، درزن، كرتون، طقم)
        Weight = 2,   // أوزان (جرام، كيلو، طن)
        Length = 3,   // أطوال (سم، متر، بوصة)
        Volume = 4,   // أحجام (ملي، لتر، جالون)
        Area = 5      // مساحات (متر مربع)
    }
}
