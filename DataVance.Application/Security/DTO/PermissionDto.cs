using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.DTO
{

    public class SystemPageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string ModuleName { get; set; }
        public string Icon { get; set; }
        public List<PageActionDto> AvailableActions { get; set; } = new();
    }
    public class PageActionDto
    {
        public string ActionCode { get; set; }
        public string DisplayName { get; set; }
        public bool IsGranted { get; set; }
        public Guid ActionId { get; set; }
        public bool IsActive { get; set; }
    }
    public class SystemActionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
    public class PermissionDto
    {
        public Guid PageId { get; set; }
        public string PageName { get; set; }
        public Guid ActionId { get; set; }
        public string ActionCode { get; set; }
        public bool IsGranted { get; set; }
    }
}


