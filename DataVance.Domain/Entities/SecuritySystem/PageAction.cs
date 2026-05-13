using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Entities.SecuritySystem
{
    public class PageAction : BaseEntity
    {
        public Guid PageId { get; private set; }
        public virtual SystemPage Page { get; private set; }

        public Guid ActionId { get; private set; }
        public virtual SystemAction Action { get; private set; }



        private PageAction() { }

        public PageAction(Guid pageId, Guid actionId)
        {
            PageId = pageId;
            ActionId = actionId;
        }
    }
}
