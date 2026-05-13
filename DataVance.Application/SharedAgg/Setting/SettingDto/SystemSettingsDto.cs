using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.Setting.SettingDto
{
    public class SystemSettingDto
    {
        public string Category { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ValueType { get; set; } = string.Empty;
        public string? LookupType { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsSystem { get; set; }
    }
}
