using DataVance.Application.Common;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.PaymentMethods;
using DataVance.Domain.ItemSystem.Enums;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.Services
{
    public class LookUpService : ILookUpService
    {
        private readonly ApplicationDbContext _context;

        public LookUpService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LookupItem>> GetBranchLookup(Guid? userId)
        {
            return await _context.UserBranches
                       .AsNoTracking()
                       .Where(x => x.UserId == userId)
                       .Select(v => new LookupItem
                       {
                           Id = v.Branch.Id,
                           Code = v.BranchId.ToString(),
                           Name = v.Branch.Name,

                       }).ToListAsync();
        }

        public async Task<List<LookupItem>> GetCurrencyLookup(Guid? AccountId, string? filter = null)
        {
            var query = _context.Currencies.AsNoTracking().Where(x => x.IsActive);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(x => x.Name.Contains(filter) || x.Code.Contains(filter));
            }
            if (AccountId.HasValue)
            {
                query = query.Where(v => _context.AccountAllowedCurrencies
                                         .Any(uw => uw.OperationId == AccountId.Value && uw.CurrencyId == v.Id));
            }
            return await query.Select(v => new LookupItem
            {
                Id = v.Id,
                CurrencyId = v.Id,
                Code = v.Code,
                Name = v.Name,
                ExchangeRate = v.CurrentExchangeRate,
                ExtraData = new Dictionary<string, string>
                                     {
                                       { "Symbol", v.Symbol.ToString() },
                                       { "IsBase", v.IsBaseCurrency.ToString().ToLower() }
                                     }
            }).ToListAsync();
        }

        public async Task<List<LookupItem>> GetWarehousesLookup(Guid? userId)
        {
            var query = _context.Warehouses.AsNoTracking().Where(w => w.IsActive);

            // 2. الفلترة حسب صلاحيات المستخدم (جدول الربط)
            if (userId.HasValue)
            {
                query = query.Where(w => _context.UserWarehouses
                             .Any(uw => uw.UserId == userId.Value && uw.WarehouseId == w.Id));
            }

            return await query.Select(v => new LookupItem
            {
                Id = v.Id,
                Code = v.Location, // نستخدم الموقع ككود أو أي حقل آخر
                Name = v.Name
            }).ToListAsync();
        }


        public async Task<List<LookupItem>> GetItemsLookup(
                                          string? searchTerm,
                                          Guid? itemGroupId = null,
                                          Guid? warehouseId = null,
                                          Guid? branchId = null,
                                          bool onlyWithBalance = false,
                                          bool isPurchase = false,
                                          bool isSales = false)
        {
            //  التعامل مع المجموعات الشجرية
            List<Guid> groupIds = new List<Guid>();
            if (itemGroupId.HasValue)
            {
                groupIds.Add(itemGroupId.Value);
                var childrenIds = await _context.ItemGroups
                    .Where(g => g.ParentCategoryId == itemGroupId)
                    .Select(g => g.Id)
                    .ToListAsync();
                groupIds.AddRange(childrenIds);
            }

            //   الاستعلام الأساسي
            var query = _context.Items.AsNoTracking().Where(x => x.IsActive);

            //  فلترة البحث النصي
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(x => x.Name.Contains(searchTerm) || x.Code.Contains(searchTerm));
            }

            //  فلترة المجموعات
            if (itemGroupId.HasValue)
            {
                query = query.Where(x => groupIds.Contains(x.ItemGroupId));
            }

            //  فلترة الرصيد
            if (onlyWithBalance && warehouseId.HasValue && branchId.HasValue)
            {
                query = query.Where(x => _context.InventoryBalances
                    .Any(b => b.ItemId == x.Id && b.BranchId == branchId && b.WarehouseId == warehouseId.Value && b.Quantity > 0));
            }

            //  التنفيذ لجلب البيانات
            return await query.Select(v => new LookupItem
            {
                Id = v.Id,
                Code = v.Code,
                Name = v.Name,
                ExtraData = v.Units
                    .Where(u =>
                        //(u.IsBaseUnit))

                        (isPurchase && u.IsPurchaseUnit) ||
                        (isSales && u.IsSalesUnit) ||
                        (!isPurchase && !isSales && u.IsBaseUnit))
                    .Select(u => new Dictionary<string, string>
                    {
                { "IdUnit", u.Id.ToString() },
                { "UnitName", u.GlobalUnit.Name },
                { "Symbol", u.GlobalUnit.Symbol },
                { "Barcode", u.Barcode ?? "" },
                { "ConversionFactor", u.ConversionFactor.ToString() },
                { "Cost",( v.CurrentCost * u.ConversionFactor).ToString() },
                { "PurchasePrice", (u.IsPurchaseUnit && isPurchase) ? (v.LastPurchasePrice * u.ConversionFactor).ToString() ?? "0" : "0"},
                { "SalePrice",
                (u.IsSalesUnit && isSales) ?
                    _context.ItemPrices
                        .Where(p => p.ItemUnitId == u.Id && p.PriceType == PriceType.Retail)
                        .Select(p => (p.Price * u.ConversionFactor).ToString())
                        .FirstOrDefault()
                    ?? "0":"0"
                },



                { "CurrentBalance", (warehouseId.HasValue && branchId.HasValue)
                    ? _context.InventoryBalances
                        .Where(b => b.ItemId == v.Id && b.WarehouseId == warehouseId.Value && b.BranchId == branchId.Value)
                        .Select(b => b.Quantity.ToString())
                        .FirstOrDefault() ?? "0"
                    : "0"
                }
                    })
                    .FirstOrDefault() ?? new Dictionary<string, string>()
            }).ToListAsync();
        }

        public async Task<List<LookupItem>> GetUnitItemLookup(
            Guid itemId,
            bool isPurchase = false,
            bool isSales = false)
        {
            return await _context.ItemUnits
                .AsNoTracking()
                .Include(c => c.Item)
                .ThenInclude(u => u!.Units.Where(d => d.Id == u.Id))
                .Include(c => c.GlobalUnit)
                .Where(x => x.ItemId == itemId)
                .Select(v => new LookupItem
                {
                    Id = v.Id,
                    Code = v.Barcode ?? "N/A", // الكود هنا هو الباركود
                    Name = v.GlobalUnit.Name ?? "الاسم مفقود",
                    ExchangeRate = v.ConversionFactor,
                    ExtraData = new Dictionary<string, string>
                    {
                { "Factor", v.ConversionFactor.ToString() },
                { "IsBase", v.IsBaseUnit.ToString().ToLower() },
                { "Cost", ( v.Item!.CurrentCost * v.ConversionFactor).ToString() },
                { "PurchasePrice",isPurchase? (v.Item.LastPurchasePrice * v.ConversionFactor).ToString() : "0" },
                { "SalePrice", isSales ?
                     _context.ItemPrices
                        .Where(p => p.ItemUnitId == v.Id &&  p.PriceType == PriceType.Retail)
                        .Select(p => p.Price.ToString())
                        .FirstOrDefault() ?? "0": "0"

                },

                    }
                }).ToListAsync();
        }
        public async Task<List<LookupItem>> GetVendorLookup()
        {
            var result = _context.Vendors
                       .AsNoTracking()
                       .Where(x => x.IsActive);

            return await result.Select(v => new LookupItem
            {
                Id = v.Id,
                Code = v.VendorCode ?? "N/A",
                Name = v.Name,
                ExtraData = new Dictionary<string, string>
                {
                    {"Phone", v.Phone!.ToString() ?? "لا يوجد" },
                    {"Email", v.Email!.ToString() ?? "لا يوجد" },
                    {"TaxNumber", v.Phone!.ToString() ?? "لا يوجد" },

                }
            }).ToListAsync();


        }
        public async Task<LookupItem?> GetItemByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return null;

            var unit = await _context.ItemUnits
                .AsNoTracking()
                .Include(u => u.Item)// تأكد من عمل Include للصنف
                .Include(u => u.GlobalUnit)  // تأكد من عمل Include للوحدة
                .FirstOrDefaultAsync(u => u.Barcode == barcode && u.Item!.IsActive);

            if (unit == null) return null;
            return new LookupItem
            {
                Id = unit.ItemId,
                Code = unit.Item!.Code,
                Name = unit.Item.Name,
                ExchangeRate = unit.ConversionFactor,
                ExtraData = new Dictionary<string, string>
                {
                    { "IdUnit", unit.Id.ToString() },
                    { "BaseUnit", unit.GlobalUnit?.Name ?? " " },
                    { "Barcode", unit.Barcode ?? " " },
                    //{ "ConversionFactor",unit.ConversionFactor.ToString() },
                    //{ "Price", _context.ItemPrices.FirstOrDefault(p => p.ItemUnitId == unit.ItemId)!.Price.ToString() ?? 0m.ToString() },
                    { "Cost", (unit.Item.CurrentCost * unit.ConversionFactor).ToString() ?? 0m.ToString() },
                    //{ "MaxPrice", _context.ItemPrices.FirstOrDefault(p => p.ItemUnitId == unit.ItemId)!.MaxPrice.ToString() ?? 0m.ToString()},
                    //{ "MinPrice", _context.ItemPrices.FirstOrDefault(p => p.ItemUnitId == unit.ItemId)!.MinPrice.ToString() ?? 0m.ToString()},

        
                }
            };

        }

        public async Task<List<LookupItem>> GetPaymentMethodType(string type)
        {
            var result = _context.FinancialAccounts
              .AsNoTracking()
              .Where(x => x.IsActive).AsQueryable();

            switch (type)
            {
                case "Cash":
                    result = result.Where(x => x.AccountType == FinancialAccountType.Cash);
                    break;
                case "Bank":
                    result = result.Where(x => x.AccountType == FinancialAccountType.Bank);
                    break;
                case "PettyCash":
                    result = result.Where(x => x.AccountType == FinancialAccountType.PettyCash);
                    break;

            }


            return await result.Select(v => new LookupItem
            {
                Id = v.Id,
                Code = v.AccountNumber ?? "N/A",
                Name = v.NameAr,
                ExtraData = new Dictionary<string, string>
                {
                    {"Phone", v.NameEn!.ToString() ?? "لا يوجد" },
                    {"Email", v.IBAN!.ToString() ?? "لا يوجد" },
                    //{"TaxNumber", v.Phone!.ToString() ?? "لا يوجد" },

                }
            }).ToListAsync();
        }

        public async Task<List<LookupItem>> GetAccountForPay()
        {
            var result = _context.Accounts
                         .AsNoTracking()
                         .Where(x => x.IsActive && x.AllowPosting).AsQueryable();

            return await result.Select(v => new LookupItem
            {
                Id = v.Id,
                Code = v.Code ?? "N/A",
                Name = v.Name,
                ExtraData = new Dictionary<string, string>
                {
                    {"DefaultCurrencyId", v.DefaultCurrencyId!.ToString() ?? Guid.Empty.ToString()},
                    {"CurrentExchangeRate", v.DefaultCurrency!.CurrentExchangeRate!.ToString() ?? (0m).ToString() },
                    {"DefaultCurrencyName", v.DefaultCurrency!.Name!.ToString() ?? "لا يوجد" }
                }
            }).ToListAsync();
        }
    }
}

