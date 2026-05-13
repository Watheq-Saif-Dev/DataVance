using Dapper;
using DataVance.Application.SharedAgg.Setting.Interface;
using DataVance.Application.SharedAgg.Setting.SettingDto;
using DataVance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Infrastructure.SettingSystem
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly IDbConnection _db;
        private readonly ApplicationDbContext _context;

        public SystemSettingsService(IDbConnection db, ApplicationDbContext context)
        {
            _db = db;
            _context = context;
        }

        public async Task<List<SystemSettingDto>> GetSettingsByCategoryAsync(string category)
        {
            const string sql = @"SELECT Category, SettingKey as [Key], DisplayName, Description, 
                                    SettingValue as [Value], ValueType, LookupType, 
                                    DisplayOrder, IsSystem 
                             FROM SystemSettings 
                             WHERE Category = @Category 
                             ORDER BY DisplayOrder";

            var result = await _db.QueryAsync<SystemSettingDto>(sql, new { Category = category });
            return result.ToList();
        }

        public async Task<bool> UpdateSettingAsync(string category, string key, string newValue)
        {
            const string sql = @"UPDATE SystemSettings 
                             SET SettingValue = @Value 
                             WHERE Category = @Category AND SettingKey = @Key";

            var rows = await _db.ExecuteAsync(sql, new { Category = category, Key = key, Value = newValue });
            return rows > 0;
        }

        public async Task<string?> GetSettingValueAsync(string key)
        {
            const string sql = "SELECT SettingValue FROM SystemSettings WHERE SettingKey = @Key";

            // الحل: تمرير الـ Transaction الحالية لـ Dapper إذا كانت موجودة
            return await _db.QueryFirstOrDefaultAsync<string>(sql,
                new { Key = key },
                transaction: _context.Database.CurrentTransaction?.GetDbTransaction());
        }
        //public async Task<string?> GetSettingValueAsync(string key)
        //{
        //    const string sql = "SELECT SettingValue FROM SystemSettings WHERE SettingKey = @Key";
        //    return await _db.QueryFirstOrDefaultAsync<string>(sql, new { Key = key });
        //}
    }
    //public class SystemSettingsService : ISystemSettingsService
    //{
    //    private readonly ApplicationDbContext _context;

    //    public SystemSettingsService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<List<SystemSettingDto>> GetByCategoryAsync(string category)
    //    {
    //        //return await _context.SystemSettings
    //        //    .Where(x => x.Category == category)
    //        //    .OrderBy(x => x.DisplayOrder)
    //        //    .Select(x => new SystemSettingDto
    //        //    {
    //        //        SettingKey = x.SettingKey,
    //        //        DisplayName = x.DisplayName,
    //        //        Description = x.Description,
    //        //        SettingValue = x.SettingValue,
    //        //        ValueType = x.ValueType,
    //        //        LookupType = x.LookupType
    //        //    })
    //        //    .ToListAsync();
    //        return await _context.SystemSettings
    //       .Where(x => x.Category == category)
    //       .OrderBy(x => x.DisplayOrder)
    //       .Select(x => new SystemSettingDto
    //       {
    //           Category = x.Category,
    //           SettingKey = x.SettingKey,
    //           DisplayName = x.DisplayName,
    //           Description = x.Description,
    //           SettingValue = x.SettingValue,
    //           ValueType = x.ValueType,
    //           LookupType = x.LookupType,
    //           DisplayOrder = x.DisplayOrder
    //       })
    //       .ToListAsync();
    //    }

    //    public async Task<string?> GetValueAsync(string key)
    //    {
    //        return await _context.SystemSettings
    //            .Where(x => x.SettingKey == key)
    //            .Select(x => x.SettingValue)
    //            .FirstOrDefaultAsync();
    //    }

    //    public async Task<Guid?> GetGuidAsync(string key)
    //    {
    //        var value = await GetValueAsync(key);

    //        if (Guid.TryParse(value, out var result))
    //            return result;

    //        return null;
    //    }

    //    public async Task<bool> GetBoolAsync(string key)
    //    {
    //        var value = await GetValueAsync(key);

    //        if (bool.TryParse(value, out var result))
    //            return result;

    //        return false;
    //    }

    //    public async Task<int> GetIntAsync(string key)
    //    {
    //        var value = await GetValueAsync(key);

    //        if (int.TryParse(value, out var result))
    //            return result;

    //        return 0;
    //    }

    //    public async Task Update(List<SystemSettingDto> settings)
    //    {
    //        foreach (var dto in settings)
    //        {
    //            var entity = await _context.SystemSettings
    //                .FirstAsync(x => x.SettingKey == dto.SettingKey);

    //            entity.UpdateValue(dto.SettingValue);
    //        }

    //        await _context.SaveChangesAsync();

    //    }
    //}
}
