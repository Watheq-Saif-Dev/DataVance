using DataVance.Domain.Common;
using DataVance.Domain.Entities.BranchSystem;
using DataVance.Domain.Finance.Shared.Entities;
using DataVance.Domain.Finance.Rules.Events;
using DataVance.Domain.Warehousing.Setup.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Warehousing.Movements.PurchaseSystem
{
    public class PurchaseReceipt : BaseBranchEntity
    {
        public string ReceiptNo { get; private set; } = null!;
        public DateTime ReceiptDate { get; private set; }
    
        public Guid VendorId { get; private set; }
        public Guid WarehouseId { get; private set; }

        public PaymentInfo Payment { get; private set; } = null!;

        public OperationContext Context { get; private set; } = null!;

        public string? Remarks { get; private set; }

        public decimal TotalAmount => _lines.Sum(x => x.TotalAmount);
        public decimal TotalTax => _lines.Sum(x => x.TotalTax);
        public decimal HeaderDiscount { get; private set; }
        public decimal TotalCost => _lines.Sum(x => x.UnitCost);

        public decimal NetFinalAmount => _lines.Sum(x => x.TotalAmount) - HeaderDiscount;
        private readonly List<PurchaseReceiptLine> _lines = new();
        public IReadOnlyCollection<PurchaseReceiptLine> Lines => _lines.AsReadOnly();

        private PurchaseReceipt() { }

        public PurchaseReceipt(string receiptNo, Guid vendorId, OperationContext context, string? remarks, Guid warehouseId, PaymentInfo payment)
        {
            Id = Guid.NewGuid();
            ReceiptNo = receiptNo;
            VendorId = vendorId;
            Context = context;
            Remarks = remarks;
            WarehouseId = warehouseId;
            ReceiptDate = DateTime.UtcNow;
            Payment = payment;
        }

        public void UpdateHeaderDiscount(decimal discount)
        {
            if (discount < 0) throw new ArgumentException("����� �� ���� �� ���� ���� �����");
            HeaderDiscount = discount;
        }

        public void AddLine(Guid itemId, Guid warehouseId, Guid unitId, decimal quantity, decimal unitCost, decimal conversionFactor, string? batchNo, DateTime? expiry, List<LinkTax> linkTaxes)
        {
            var line = new PurchaseReceiptLine(Id, itemId, warehouseId, unitId, quantity, unitCost, conversionFactor, batchNo, expiry);
            foreach (var tax in linkTaxes)
            {

                line.AddTax(new LinkTax(
                    tax.ReferenceId,
                   "PUR-RECEBT",
                    tax.TaxCodeId,
                    tax.TaxName!,
                    tax.TaxRate,
                    tax.Amount

                ));
            }

            _lines.Add(line);
        }

        public void Confirm()
        {

            AddDomainEvent(new PostToAccountingEvent(
                ReferenceId: this.Id,
                OperationCode: "PUR_RCT",
                EventDate: ReceiptDate,
                BranchId: this.BranchId
            ));
        }
    }
}


