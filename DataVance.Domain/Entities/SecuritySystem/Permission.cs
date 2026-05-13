using DataVance.Domain.Common;
using DataVance.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.SecuritySystem
{
    //public class Permission :BaseEntity
    //{
    //    public Guid TargetId { get; set; } // يمكن أن يكون RoleId أو UserId
    //    public PermissionTarget TargetType { get; set; }
    //    public Guid PageId { get; set; }
    //    public virtual SystemPage? Page { get; set; }
    //    // الصلاحيات
    //    public string ActionCode { get; set; } = ""; // نخزن الكود "View" أو "Transfer" لسهولة القراءة والسرعة

    //    // 4. القيمة (مسموح أم لا)
    //    public bool IsGranted { get; set; } // True = مسموح, False = ممنوع
    //}

    public class Permission : BaseEntity
    {
        public Guid TargetId { get; private set; } // RoleId or UserId
        public PermissionTarget TargetType { get; private set; }
        public Guid PageId { get; private set; }
        public virtual SystemPage Page { get; private set; }

        public Guid ActionId { get; private set; }
        public virtual SystemAction Action { get; private set; }

        public string ActionCode { get; private set; } // للسرعة
        public bool IsGranted { get; private set; }

        private Permission() { }

        // Factory Method لضمان بناء الصلاحية بشكل صحيح
        public static Permission Create(Guid targetId, PermissionTarget targetType, Guid pageId, Guid actionId, string actionCode)
        {
            return new Permission
            {
                Id = Guid.NewGuid(),
                TargetId = targetId,
                TargetType = targetType,
                PageId = pageId,
                ActionId = actionId,
                ActionCode = actionCode,
                IsGranted = true // عند الإنشاء تكون مفعلة تلقائياً
            };
        }

        // Behaviors (أفعال النطاق)
        public void ToggleStatus(bool isGranted)
        {
            IsGranted = isGranted;
        }

        public void Revoke() => IsGranted = false;
        public void Grant() => IsGranted = true;
    }
}
