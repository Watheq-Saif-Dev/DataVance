using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.Setting.SettingCommend
{
    public record UpdateSettingCommand(string Category, string Key, string Value) : IRequest<bool>;
}
