using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Commands
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HasPermissionAttribute : Attribute
    {
        public string PageCode { get; }
        public string ActionCode { get; }

        public HasPermissionAttribute(string pageCode, string actionCode)
        {
            PageCode = pageCode;
            ActionCode = actionCode;
        }
    }
}
