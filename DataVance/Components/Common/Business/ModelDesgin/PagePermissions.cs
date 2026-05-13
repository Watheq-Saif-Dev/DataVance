namespace DataVance.Components.Common.Business.ModelDesgin
{
    public class PagePermissions
    {
        public bool CanSave { get; set; } = true;
        public bool CanEdit { get; set; } = false;
        public bool CanDelete { get; set; } = false;
        public bool CanPrint { get; set; } = true;
        public bool CanPost { get; set; } = false;
        public bool CanApprove { get; set; } = false;
    }
}

