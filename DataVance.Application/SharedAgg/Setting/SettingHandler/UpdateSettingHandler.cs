using DataVance.Application.Common.Interfaces;
using DataVance.Application.SharedAgg.Setting.Interface;
using DataVance.Application.SharedAgg.Setting.SettingCommend;
using DataVance.Domain.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.Setting.SettingHandler
{
    public class UpdateSettingHandler : IRequestHandler<UpdateSettingCommand, bool>
    {
        private readonly ISystemSettingsService _settingService;
        public UpdateSettingHandler(ISystemSettingsService settingService) => _settingService = settingService;

        public async Task<bool> Handle(UpdateSettingCommand request, CancellationToken ct)
        {
            return await _settingService.UpdateSettingAsync(request.Category, request.Key, request.Value);
        }
    }
}
