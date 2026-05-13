using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.WarehouseSystem
{
    public class Vendor : AggregateRoot
    {
        public string Name { get; private set; } = null!;
        public string? VendorCode { get; private set; } // رقم فريد للمورد
        public string? TaxNumber { get; private set; } // الرقم الضريبي
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }

        // لإدارة الديون (المحاسبة)
        public Guid AccountId { get; private set; } // ربط المورد بشجرة الحسابات (Account ID)
        public bool IsActive { get; private set; }

        private Vendor() { }

        public Vendor(string name, string? vendorCode, string? taxNumber, Guid accountId)
        {
            Id = Guid.NewGuid();
            Name = name;
            VendorCode = vendorCode;
            TaxNumber = taxNumber;
            AccountId = accountId;
            IsActive = true;
        }

        public void UpdateContactInfo(string? phone, string? email, string? address)
        {
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}
