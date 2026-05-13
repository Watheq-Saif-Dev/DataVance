using DataVance.Application.Security.DTO;
using DataVance.Application.Security.Queries;
using DataVance.Application.Security.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Handler.ActionPage
{
    public class GetPageActionsHandler : IRequestHandler<GetPageActionsQuery, List<SystemActionDto>>
    {
        private readonly IPermissionService _permission;

        public GetPageActionsHandler(IPermissionService permission)
        {
            _permission = permission;
        }
        public async Task<List<SystemActionDto>> Handle(GetPageActionsQuery request, CancellationToken cancellationToken)
        {
            var allActions = await _permission.GutPageActionWithActivation(request.pageId, cancellationToken);
            return allActions;
        }
    }

}
