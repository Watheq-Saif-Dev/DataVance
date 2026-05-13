using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.AuditSystem
{
    public class AuditLog : BaseEntity
    {
        public Guid? UserId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty; // مثل: Login, SwitchBranch
        public string Details { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public string? TableName { get; set; }   // الجدول المتأثر
        public DateTime DateTime { get; set; }  // وقت الحدوث
        public string? KeyValues { get; set; }  // المعرف الأساسي (RoleId مثلاً)
        public string? OldValues { get; set; }  // القيم قبل التعديل
        public string? NewValues { get; set; }   // القيم بعد التعديل
        public string? DeviceInfo { get; set; }
    }
}
