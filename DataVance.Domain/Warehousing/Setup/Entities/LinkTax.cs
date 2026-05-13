using DataVance.Domain.Common;
using DataVance.Domain.Warehousing.Movements.PurchaseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Warehousing.Setup.Entities
{
    public class LinkTax : Entity
    {
        // مرجع لأي مستند (فاتورة شراء، بيع، سند صرف، إلخ)
        public Guid ReferenceId { get; private set; }
        // كود العملية لتمييز المستندات (مثلاً: "Purchase", "Sales")
        public string OperationCode { get; private set; } = null!;

        // بيانات الضريبة
        public Guid TaxCodeId { get; private set; }
        public string? TaxName { get; private set; }
        public decimal TaxRate { get; private set; }
        public decimal Amount { get; private set; }

        private LinkTax() { }

        public LinkTax(Guid ReferenceId, string OperationCode, Guid taxCodeId, string name, decimal rate, decimal amount)
        {
            Id = Guid.NewGuid();
            TaxCodeId = taxCodeId;
            TaxName = name;
            TaxRate = rate;
            Amount = amount;
        }

        // السطر هو من يطلب من الضريبة حساب نفسها
        internal void Calculate(decimal baseAmount)
        {
            Amount = Math.Round(baseAmount * TaxRate, 2);
        }
        // اختيارياً: ربط مع كود الضريبة الأساسي لجلب البيانات منه

    }
}

