using DataVance.Application.Common;
using DataVance.Application.Features.PurchaseTransactions.Commend;
using DataVance.Application.Features.PurchaseTransactions.DTO;
using DataVance.Components.Common.Business.ModelDesgin;
using DataVance.Domain.Finance.PaymentMethods;
using System.Collections.Generic;

namespace DataVance.Components.Pages.Transaction.Inventory
{
    public partial class Purchase_Receipts
    {
        private string SelectedVendorName = "";


        private PagePermissions _pagePermissions = new();
        private PurchaseReceiptViewModel ReceiptModel { get; set; } = new();
        private Guid SelectedAccountId => ReceiptModel.FinancialAccountId ?? ReceiptModel.VendorId;


        private bool IsSubmitting = false;
        protected override async Task OnInitializedAsync()
        {

            _pagePermissions = new PagePermissions { CanSave = true, CanPrint = true, CanPost = true };
            ReceiptModel.Items = new();

        }

        private void HandlePaymentMethodChange(PaymentMethodType method)
        {
            ReceiptModel.PaymentMethod = method;

            ReceiptModel.FinancialAccountId = null;
            ReceiptModel.FinancialAccountName = "اختر الحساب";
            StateHasChanged();
        }


        private async Task ProcessBarcode(string barcode)
        {
            var result = await lookUpService.GetItemByBarcode(barcode);
            if (result == null) return;

            if (result.ExtraData != null && result.ExtraData.TryGetValue("IdUnit", out var cId))
            {

                var unitId = Guid.Parse(cId);
                var existing = ReceiptModel.Items.FirstOrDefault(x => x.ItemId == result.Id && x.UnitId == unitId);
                if (existing != null)
                {
                    existing.Quantity++;
                }

                else
                {
                    ReceiptModel.Items.Add(new ReceiptItemDtoViewModel
                    {
                        ItemId = result.Id,
                        ItemName = result.Name,
                        Quantity = 1,
                        UnitId = result.ExtraData!.ContainsKey("IdUnit") ? Guid.Parse(result.ExtraData["IdUnit"]) : Guid.Empty,
                        UnitName = result.ExtraData.GetValueOrDefault("BaseUnit", ""),
                        UnitPriceOrCost = decimal.Parse(result.ExtraData.GetValueOrDefault("Price", "0")),
                        UnitCost = decimal.Parse(result.ExtraData.GetValueOrDefault("Cost", "0")),
                        ConversionFactor = result.ExchangeRate,
                        Barcode = barcode,
                        WarehouseId = ReceiptModel.DefaultWarehouseId,
                        WarehouseName = ReceiptModel.WarehouseName,
                        BranchId = ReceiptModel.BranchId,
                        DiscountAmountForUnit = 0,
                        TaxSummaries = new List<TaxSummaryViewModel>()
                    });
                }
            }
            StateHasChanged();
        }
        private CreatePurchaseReceiptCommand CreateCommandFromModel()
        {
            return new CreatePurchaseReceiptCommand(
                ReceiptNo: ReceiptModel.ReceiptNo,
                PaymentMethod: ReceiptModel.PaymentMethod,
                FinancialAccountId: ReceiptModel.FinancialAccountId,
                FinancialAccountName: ReceiptModel.FinancialAccountName,
                PaymentReferenceNo: ReceiptModel.PaymentReferenceNo,
                VendorId: ReceiptModel.VendorId,
                BranchId: ReceiptModel.BranchId,
                UserId: UserContext.UserId,
                CurrencyId: ReceiptModel.CurrencyId,
                ExchangeRate: ReceiptModel.ExchangeRate,
                CurrCode: ReceiptModel.CurrCode,
                warehouseId: ReceiptModel.DefaultWarehouseId,
                HeaderDiscount: ReceiptModel.HeaderDiscount,
                Items: ReceiptModel.Items.Select(i => new ReceiptItemDto(
                    i.ItemId,
                    i.ItemName,
                    i.WarehouseId,
                    i.UnitId,
                    i.Quantity,
                    i.UnitPriceOrCost,
                    i.ConversionFactor,
                    i.DiscountAmountForUnit,
                    i.BatchNumber ?? "",
                    i.ExpiryDate
                )).ToList()
            );
        }

        private decimal CalculateFinalTotal()
        {
            decimal subTotal = ReceiptModel.Items.Sum(x => x.Quantity * x.UnitPriceOrCost);
            decimal itemsDiscount = ReceiptModel.Items.Sum(x => x.DiscountAmountForAllQty);
            decimal totalTax = ReceiptModel.Items.Sum(x => x.TotalTax);
            decimal headerDiscount = ReceiptModel.HeaderDiscount;
            return (subTotal - itemsDiscount - headerDiscount) + totalTax;
        }



        private void HandleHeaderWarehouseSelected(LookupItem res)
        {
            if (res == null) return;
            ReceiptModel.DefaultWarehouseId = res.Id;
            ReceiptModel.WarehouseName = res.Name;
            foreach (var item in ReceiptModel.Items)
            {
                item.WarehouseId = res.Id;
                item.WarehouseName = res.Name;
            }
        }
        private void OnFinancialAccountSelected(LookupItem item)
        {
            if (item != null)
            {
                ReceiptModel.FinancialAccountName = item.Name;
                ReceiptModel.FinancialAccountId = item.Id;
                if (item.ExtraData != null && item.ExtraData.TryGetValue("DefaultCurrencyId", out var cId))
                    ReceiptModel.CurrencyId = cId != null ? Guid.Parse(cId) : Guid.Empty;

                item.ExtraData!.TryGetValue("CurrentExchangeRate", out var cl);
                ReceiptModel.ExchangeRate = cl != null ? decimal.Parse(cl) : 0m;

                ReceiptModel.CurrCode = item.ExtraData!.ContainsKey("DefaultCurrencyName") ? item.ExtraData["DefaultCurrencyName"] : "YER";
                StateHasChanged();
            }
        }
        private void HandleCurrencySelection(LookupItem res)
        {
            ReceiptModel.CurrencyId = res.Id;
            ReceiptModel.CurrCode = res.Name;
            ReceiptModel.ExchangeRate = res.ExchangeRate;

        }
        private void HandleVendorSelection(LookupItem res)
        {
            if (res == null) return;
            ReceiptModel.VendorId = res.Id;
            SelectedVendorName = res.Name;
            if (res.ExtraData != null && res.ExtraData.TryGetValue("CurrencyId", out var cId))
            {
                ReceiptModel.CurrencyId = Guid.Parse(cId);
                ReceiptModel.CurrCode = res.ExtraData.GetValueOrDefault("CurrencyName", ReceiptModel.CurrCode.ToString());
                ReceiptModel.ExchangeRate = decimal.Parse(res.ExtraData.GetValueOrDefault("ExchangeRate", ReceiptModel.CurrencyId.ToString()));
            }
            StateHasChanged();
        }

        protected override async Task OnSaveShortcut()
        {
            await SaveReceipt();

        }
        private async Task SaveReceipt()
        {
            if (!ReceiptModel.Items.Any(x => x.ItemId != Guid.Empty))
                throw new Exception("يرجى إضافة أصناف للفاتورة قبل الحفظ");

            IsSubmitting = true;
            try
            {
                var command = CreateCommandFromModel();
                var result = await ExecuteAsync(command, "تمت عملية الشراء بنجاح");
                if (result)
                {
                    ClearForm();
                }
            }
            catch (Exception ex)
            {

                StatusService.ShowMessage($"تعذر الخفظ{ex.Message}");
            }
            finally
            {
                IsSubmitting = false;
            }
        }
        private void ClearForm()
        {
            ReceiptModel = new PurchaseReceiptViewModel();
            ReceiptModel.Items = new List<ReceiptItemDtoViewModel>();
            SelectedVendorName = "";
            ReceiptModel.CurrCode = "YER";
            StateHasChanged();
        }

    }
}



