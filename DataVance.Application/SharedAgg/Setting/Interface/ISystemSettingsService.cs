using DataVance.Application.SharedAgg.Setting.SettingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.Setting.Interface
{
    public interface ISystemSettingsService
    {






        Task<List<SystemSettingDto>> GetSettingsByCategoryAsync(string category);
        Task<bool> UpdateSettingAsync(string category, string key, string newValue);
        Task<string?> GetSettingValueAsync(string key);


    }
}

