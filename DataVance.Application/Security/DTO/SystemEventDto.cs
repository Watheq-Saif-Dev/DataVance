using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.DTO
{
    public class SystemEventDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
    }
}

