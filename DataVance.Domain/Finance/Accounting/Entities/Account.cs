using DataVance.Domain.Common;
using DataVance.Domain.Finance.Currencies.Entities;
using DataVance.Domain.Finance.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Finance.Accounting.Entities
{
    public class Account : AggregateRoot
    {
        public string Code { get; private set; } = "";
        public string Name { get; private set; } = "";
        public AccountType Type { get; private set; }
        public Guid? ParentId { get; private set; }
        public bool AllowPosting { get; private set; }
        public bool IsActive { get; private set; }
        public Guid? DefaultCurrencyId { get; private set; }
        public virtual Currency? DefaultCurrency { get; private set; }

        // قائمة العملات المسموح بالترحيل بها لهذا الحساب
        private readonly List<AccountAllowedCurrency> _allowedCurrencies = new();
        public virtual IReadOnlyCollection<AccountAllowedCurrency> AllowedCurrencies => _allowedCurrencies;

        private Account() { }
        public Account(string code, string name, AccountType type, Guid? parentId)
        {
            Code = code;
            Name = name;
            Type = type;
            ParentId = parentId;
            AllowPosting = true;
            IsActive = true;
        }

        public void SetDefaultCurrency(Guid? currencyId) => DefaultCurrencyId = currencyId;

        public void AddAllowedCurrency(Guid currencyId)
        {
            if (!_allowedCurrencies.Any(c => c.CurrencyId == currencyId))
                _allowedCurrencies.Add(new AccountAllowedCurrency(Id, currencyId));
        }
        public void ClearAllowedCurrencies() => _allowedCurrencies.Clear();

        public void Disable()
        {
            if (!IsActive)
                throw new InvalidOperationException("Account already inactive.");

            IsActive = false;

        }
        public void Activate()
        {
            if (IsActive)
                throw new InvalidOperationException("Account is already active.");

            IsActive = true;
        }

        public void SetAsParent()
        {
            AllowPosting = false;
        }

        public void SetAsChild()
        {
            // الحسابات الفرعية هي التي تسمح بالترحيل المباشر عليها
            AllowPosting = true;
        }
        public void Rename(string name)
        {
            Name = name;
        }
    }
}

