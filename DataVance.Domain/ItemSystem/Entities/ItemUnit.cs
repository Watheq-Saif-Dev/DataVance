using DataVance.Domain.Common;
using DataVance.Domain.ItemSystem.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.Entities
{
    public class ItemUnit : Entity
    {
        public Guid ItemId { get; private set; }
        public Item? Item { get; set; }



        public Guid GlobalUnitId { get; private set; }
        public virtual GlobalUnit GlobalUnit { get; private set; } = null!;


        public decimal ConversionFactor { get; private set; }

        public bool IsBaseUnit { get; private set; }
        public bool IsSalesUnit { get; private set; }     // هل تظهر في شاشة المبيعات؟
        public bool IsPurchaseUnit { get; private set; }  // هل تظهر في شاشة المشتريات؟
        public string? Barcode { get; private set; } // الباركود الخاص بهذه الوحدة (مثلاً للحبة أو للكرتون)

        internal ItemUnit() { }

        internal ItemUnit(Guid itemId, Guid globalUnitId, decimal factor, bool isBase, bool isSales, bool isPurchase, string? barcode)
        {
            ItemId = itemId;
            GlobalUnitId = globalUnitId;
            ConversionFactor = factor;
            IsBaseUnit = isBase;
            IsSalesUnit = isSales;
            IsPurchaseUnit = isPurchase;
            Barcode = barcode;
        }


        public void SetBarcode(string barcode)
        {
            // التحقق من صحة الباركود أو عدم تكراره يمكن أن يتم في Domain Service

            Barcode = barcode;
        }
    }
}

