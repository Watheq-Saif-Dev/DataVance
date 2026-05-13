using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.Entities
{
    public class ItemGroup : AggregateRoot
    {
        public string Name { get; private set; } = null!;
        public string Code { get; private set; } = null!;
        public bool IsActive { get; private set; }

        // نظام الشجرة
        public Guid? ParentCategoryId { get; private set; }
        public virtual ItemGroup? ParentCategory { get; private set; }

        private readonly List<ItemGroup> _children = new();
        public virtual IReadOnlyCollection<ItemGroup> Children => _children.AsReadOnly();

        private readonly List<CategoryTax> _taxes = new();
        public IReadOnlyCollection<CategoryTax> Taxes => _taxes.AsReadOnly();

        // Constructor لـ EF Core
        private ItemGroup() { }

        // الباني الرئيسي
        public ItemGroup(string name, string code, Guid? parentId = null)
        {
            Id = Guid.NewGuid(); // تأكد أن AggregateRoot يدعم تعيين Id
            Update(name, code);
            ParentCategoryId = parentId;
            IsActive = true;
        }


        public void Update(string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is required");

            Name = name;
            Code = code;
        }

        public void AddSubGroup(ItemGroup child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));

            // منع إضافة المجموعة لنفسها كأب
            if (child.Id == this.Id)
                throw new InvalidOperationException("Category cannot be its own parent.");

            // ضبط الأب للمجموعة الفرعية
            child.ParentCategoryId = this.Id;
            _children.Add(child);
        }
        public void AddTax(Guid taxCodeId, int order)
        {
            if (_taxes.Any(t => t.TaxCodeId == taxCodeId))
                throw new InvalidOperationException("This tax is already added to this group.");

            _taxes.Add(new CategoryTax(taxCodeId, order));
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
    }

}

