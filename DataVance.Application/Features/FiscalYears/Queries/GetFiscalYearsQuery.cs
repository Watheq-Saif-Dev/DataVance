using DataVance.Application.Features.FiscalYears.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.FiscalYears.Queries
{
    public record GetFiscalYearsQuery() : IRequest<List<FiscalYearDto>>;
}

