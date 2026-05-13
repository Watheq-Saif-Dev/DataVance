using DataVance.Domain.Common;
using DataVance.Domain.ItemSystem.Enums;

namespace DataVance.Domain.ItemSystem.ValueObjects
{
    public class UnitCategory : AggregateRoot
    {
        public string Name { get; private set; } = null!; // مثال: "وحدات الأوزان"
        public MeasurementType Type { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }

        // قائمة الوحدات العامة التابعة لهذه الفئة
        private readonly List<GlobalUnit> _globalUnits = new();
        public virtual IReadOnlyCollection<GlobalUnit> GlobalUnits => _globalUnits.AsReadOnly();

        internal UnitCategory() { } // لـ EF Core

        public UnitCategory(string name, MeasurementType type, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Description = description;
            IsActive = true;
        }

        // دالة إضافة وحدة جديدة لهذه الفئة
        public void AddGlobalUnit(string name, string symbol)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("اسم الوحدة مطلوب");
            if (_globalUnits.Any(u => u.Name == name)) throw new InvalidOperationException("هذه الوحدة موجودة مسبقاً");

            _globalUnits.Add(new GlobalUnit(Id, name, symbol));
        }
    }
}

