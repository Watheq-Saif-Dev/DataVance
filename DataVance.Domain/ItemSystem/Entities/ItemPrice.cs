using DataVance.Domain.Common;
using DataVance.Domain.ItemSystem.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.Entities
{
    public class ItemPrice : Entity
    {
        public Guid ItemId { get; private set; }
        public Guid ItemUnitId { get; private set; } // السعر مرتبط بوحدة محددة (حبة أو كرتون)
        public virtual ItemUnit ItemUnit { get; private set; } = null!;

        public PriceType PriceType { get; private set; } // Enum: Retail, Wholesale, Distributor


        public decimal Price { get; private set; }

        public Guid CurrencyId { get; private set; } // العملة (مهم جداً في اليمن)

        public decimal MinPrice { get; private set; }
        public decimal MaxPrice { get; private set; }

        public DateTime FromDate { get; private set; } // بداية سريان السعر
        public DateTime? ToDate { get; private set; }   // نهاية السريان (للعروض)

        internal ItemPrice() { }

        public ItemPrice(Guid itemId, Guid itemUnitId, decimal price, PriceType priceType)
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            ItemUnitId = itemUnitId;
            Price = price;
            PriceType = priceType;
            FromDate = DateTime.Now;
        }
    }


}

