using DataVance.Application.DTOs;
using DataVance.Application.Security.DTO;


namespace DataVance.Application.Security.DTO.Models
{
    public class PermissionsEditViewModel
    {
        public List<ActionDto> AllActions { get; set; } = new();
        public List<PagePermissionRowDto> Rows { get; set; } = new();
    }
    public record PagePermissionRowDto(Guid PageId, string PageName)
    {
        public List<string> GrantedActionCodes { get; set; } = new();

    }
    public record ActionDto(Guid Id, string Code, string DisplayName);


}

