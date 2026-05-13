using DataVance.Application.Security.Commands;
using DataVance.Application.Security.Service;
using DataVance.Domain.Entities.SecuritySystem;
using MediatR;

namespace DataVance.Application.Security.Handler.ActionPage
{
    public class UpdateActionPageHandler : IRequestHandler<UpdateActionPageCommand, bool>
    {
        private readonly IPermissionService _permission;

        public UpdateActionPageHandler(IPermissionService permission)
        {
            _permission = permission;
        }
        public async Task<bool> Handle(UpdateActionPageCommand request, CancellationToken cancellationToken)
        {
            var PageRes = await _permission.GutPageActionWithActivation(request.PageId, cancellationToken);

            foreach (var actionPage in request.PageAction)
            {
                var PageAction = PageRes.FirstOrDefault(p =>
                    p.Id == actionPage.ActionId);

                if (PageAction != null && PageAction.IsActive && !actionPage.IsActive)
                {
                    await _permission.RemovePageActionAsync(PageAction.Id, request.PageId, cancellationToken);

                }
                else if (actionPage.IsActive && !PageAction!.IsActive)
                {

                    var newPageAction = new PageAction(
                       request.PageId,
                       actionPage.ActionId
                        );

                    await _permission.AddPageActionAsync(newPageAction);
                }
            }
            return true;
        }
    }
}
