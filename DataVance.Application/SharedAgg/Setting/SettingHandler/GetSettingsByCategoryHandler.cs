using Dapper;
using DataVance.Application.SharedAgg.Setting.Interface;
using DataVance.Application.SharedAgg.Setting.SettingDto;
using DataVance.Application.SharedAgg.Setting.SettingQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.Setting.SettingHandler
{
    public class GetSettingsByCategoryHandler : IRequestHandler<GetSettingsByCategoryQuery, List<SystemSettingDto>>
    {
        private readonly ISystemSettingsService _settingService;
        public GetSettingsByCategoryHandler(ISystemSettingsService settingService) => _settingService = settingService;

        public async Task<List<SystemSettingDto>> Handle(GetSettingsByCategoryQuery request, CancellationToken ct)
        {
            return await _settingService.GetSettingsByCategoryAsync(request.Category);
        }


    }
}

