using DataVance.Application.AlertServices;
using DataVance.Components.Shared.GenericeModal;
using DataVance.Domain.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataVance.Application.Common;

namespace DataVance.Components.Shared
{
    public abstract class DataVanceBasePage : PermissionPageBase, IDisposable
    {
        [Inject] protected IMediator Mediator { get; set; } = default!;
        [Inject] protected IStatusMessageService StatusService { get; set; } = default!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

        protected bool IsLoading { get; set; }

        protected async Task<TResponse?> ExecuteAsync<TResponse>(IRequest<TResponse> request, string successMessage = "")
        {
            IsLoading = true;
            StatusService.SetLoadingState(true);
            try
            {
                var result = await Mediator.Send(request);

                if (result is Result domainResult)
                {
                    if (domainResult.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(successMessage))
                            StatusService.ShowMessage(successMessage, false);
                    }
                    else
                    {
                        var errorMsg = domainResult.Errors != null && domainResult.Errors.Any()
                            ? string.Join(", ", domainResult.Errors)
                            : "ط­ط¯ط« ط®ط·ط£ ط£ط«ظ†ط§ط، طھظ†ظپظٹط° ط§ظ„ط¹ظ…ظ„ظٹط©";
                        StatusService.ShowMessage(errorMsg, true);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(successMessage))
                        StatusService.ShowMessage(successMessage, false);
                }

                return result;
            }
            catch (InvalidOperationException ex)
            {
                StatusService.ShowMessage(ex.Message, true);
            }
            catch (Exception ex)
            {
                StatusService.ShowMessage("ط®ط·ط£ طھظ‚ظ†ظٹ: طھط¹ط°ط± ط¥ظƒظ…ط§ظ„ ط§ظ„ط¹ظ…ظ„ظٹط©", true);
            }
            finally
            {
                IsLoading = false;
                StatusService.SetLoadingState(false);
                StateHasChanged();
            }
            return default;
        }

        private DotNetObjectReference<DataVanceBasePage>? _objRef;
        protected LookupModal GenericModal { get; set; } = default!;
        private Action<LookupItem>? _onSelectAction;
        public IFocusableLookup? ActiveLookup { get; set; }

        public async Task DisplayModalOnly(string title,
                                         List<LookupItem> data,
                                         Action<LookupItem> onSelect,
                                         Dictionary<string, string>? columns = null)
        {
            _onSelectAction = onSelect;

            if (GenericModal != null)
            {
                GenericModal.Show(title, data, columns);
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("console.error", "GenericModal is missing in .razor file!");
            }
        }

        protected void HandleItemSelected(LookupItem item) => _onSelectAction?.Invoke(item);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _objRef = DotNetObjectReference.Create(this);
                await JSRuntime.InvokeVoidAsync("registerGlobalKeyDown", _objRef);
            }
        }

        [JSInvokable]
        public virtual async Task HandleGlobalKeyDown(string key)
        {
            switch (key)
            {
                case "F10": await OnSaveShortcut(); break;
                case "F3": await OnNewShortcut(); break;
                case "F2": await OnSearchShortcut(); break;
                case "F9":
                    if (ActiveLookup != null) await ActiveLookup.OpenSearch();
                    break;
                case "Enter":
                    await JSRuntime.InvokeVoidAsync("focusNextElement");
                    break;
            }
        }

        protected virtual Task OnSaveShortcut() => Task.CompletedTask;
        protected virtual Task OnNewShortcut() => Task.CompletedTask;
        protected virtual Task OnSearchShortcut() => Task.CompletedTask;

        public virtual void Dispose() => _objRef?.Dispose();
    }
}


