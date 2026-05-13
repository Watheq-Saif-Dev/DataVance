using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.PurchaseTransactions.DTO
{
    public class CreatePurchaseReceiptDto
    {
        public string ReceiptNo { get; set; } = string.Empty;
        public Guid VendorId { get; set; }
        public Guid BranchId { get; set; }
        public string? Remarks { get; set; }
        public List<ReceiptItemDto> Items { get; set; } = new();
    }
}
