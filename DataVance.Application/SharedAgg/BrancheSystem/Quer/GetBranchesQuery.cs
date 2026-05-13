using DataVance.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.BrancheSystem.Quer
{
    public record GetBranchesQuery(string email) : IRequest<List<BranchDto>>;
}
