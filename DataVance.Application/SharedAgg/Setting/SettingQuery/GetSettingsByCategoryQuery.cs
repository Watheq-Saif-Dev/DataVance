using DataVance.Application.SharedAgg.Setting.SettingDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.Setting.SettingQuery
{
    public record GetSettingsByCategoryQuery(string Category) : IRequest<List<SystemSettingDto>>;
}
