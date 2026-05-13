using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.Commands
{
    public record TogglePeriodStatusCommand(Guid PeriodId, bool IsClosed) : IRequest<bool>;

}

