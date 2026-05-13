using DataVance.Domain.Common;

namespace DataVance.Domain.Entities.EventSystem
{
    public class SystemEvent : BaseEntity
    {
        public string? Code { get; private set; }
        // مثال: SaveInvoice, PrintInvoice, ApplyDiscount

        public string? DisplayName { get; private set; }
        // الاسم الظاهر للمستخدم

        public string? Module { get; private set; }
        // Sales / Inventory / Accounting

        public bool IsActive { get; private set; }
        public bool IsGlobal { get; private set; } = false;


        private readonly List<EventPermission> _permissions = new();
        private readonly List<EventTrigger> _triggers = new();
        public IReadOnlyCollection<EventPermission> Permissions => _permissions.AsReadOnly();
        public IReadOnlyCollection<EventTrigger> Triggers => _triggers.AsReadOnly();

        private SystemEvent() { }

        public SystemEvent(string code, string displayName, string module)
        {
            Id = Guid.NewGuid();
            Update(code, displayName, module);
            IsActive = true;
        }
        public void Update(string code, string displayName, string module)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is required.");

            Code = code;
            DisplayName = displayName;
            Module = module;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

        public void AddPermission(EventPermission permission)
        {
            // منع إضافة نفس الهدف مرتين لنفس الحدث
            if (_permissions.Any(p => p.TargetId == permission.TargetId && p.TargetType == permission.TargetType))
                throw new InvalidOperationException("Permission already exists for this target.");

            _permissions.Add(permission);
        }
        public void RemovePermission(Guid permissionId)
        {
            var permission = _permissions.FirstOrDefault(p => p.Id == permissionId);
            if (permission != null)
                _permissions.Remove(permission);
        }
        public void SetGlobal(bool isGlobal) => IsGlobal = isGlobal;
        public void AddTrigger(EventTrigger trigger)
        {
            if (_triggers.Any(t => t.OperationCode == trigger.OperationCode))
                throw new InvalidOperationException("Trigger with same operation code already exists.");
            _triggers.Add(trigger);
        }
    }
}
