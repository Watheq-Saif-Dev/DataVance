using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.SecuritySystem
{
    //public class SystemPage
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }        // اسم الصفحة البرمجي (Warehouses)
    //    public string DisplayName { get; set; } // الاسم العربي (إدارة المخازن)
    //    public string Module { get; set; }      // القسم (Inventory)
    //}
    public class SystemPage : BaseEntity
    {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string ModuleName { get; private set; }
        public string Icon { get; private set; }
        public string Route { get; private set; }

        // استخدام Private Field مع IReadOnlyCollection لمنع التعديل الخارجي على القائمة
        private readonly List<PageAction> _availableActions = new();
        public virtual IReadOnlyCollection<PageAction> AvailableActions => _availableActions.AsReadOnly();

        private SystemPage() { }

        public SystemPage(string name, string displayName, string moduleName, string route, string icon = "")
        {
            Name = name;
            DisplayName = displayName;
            ModuleName = moduleName;
            Route = route;
            Icon = icon;
        }

        // منطق الـ Domain: إضافة عملية متاحة لهذه الصفحة
        public void AddAvailableAction(Guid actionId)
        {
            if (_availableActions.Any(a => a.ActionId == actionId)) return;
            _availableActions.Add(new PageAction(this.Id, actionId));
        }
    }
}
