using DataVance.Domain.Common;


namespace DataVance.Domain.Entities.SecuritySystem
{
    //public class SystemAction : BaseEntity
    //{
    //    public string Code { get; set; } // مثال: "View", "Create", "Transfer", "Approve"
    //    public string DisplayName { get; set; } // مثال: "عرض", "إضافة", "تحويل مخزني", "اعتماد"
    //    public int SortOrder { get; set; } // لترتيب ظهورها في الشاشة
    //}
    public class SystemAction : BaseEntity
    {
        public string Code { get; private set; }
        public string DisplayName { get; private set; }
        public int SortOrder { get; private set; }

        private SystemAction() { } // للمحرك EF Core

        public SystemAction(string code, string displayName, int sortOrder)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Action code is required.");
            Code = code;
            DisplayName = displayName;
            SortOrder = sortOrder;
        }

        public void UpdateDetails(string displayName, int sortOrder)
        {
            DisplayName = displayName;
            SortOrder = sortOrder;
        }
    }
}

