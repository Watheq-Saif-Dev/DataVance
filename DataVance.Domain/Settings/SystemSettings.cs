using DataVance.Domain.Common;

namespace DataVance.Domain.Settings
{


    public class SystemSetting : Entity
    {
        public string Category { get; private set; }      // Accounting, Customers, Inventory
        public string SettingKey { get; private set; }    // OpeningBalanceAccountId
        public string DisplayName { get; private set; }   // اسم يظهر في الواجهة
        public string Description { get; private set; }   // شرح الإعداد
        public string SettingValue { get; private set; }  // القيمة
        public string ValueType { get; private set; }     // String, Bool, Guid, Int
        public string? LookupType { get; private set; }   // Accounts, Currencies
        public int DisplayOrder { get; private set; }     // ترتيب العرض
        public bool IsSystem { get; private set; }        // يمنع الحذف

        private SystemSetting() { }

        public SystemSetting(
            string category,
            string key,
            string displayName,
            string description,
            string value,
            string type,
            string? lookupType,
            int order,
            bool isSystem)
        {
            Category = category;
            SettingKey = key;
            DisplayName = displayName;
            Description = description;
            SettingValue = value;
            ValueType = type;
            LookupType = lookupType;
            DisplayOrder = order;
            IsSystem = isSystem;
        }

        public void UpdateValue(string value)
        {
            SettingValue = value;
        }
    }
}
