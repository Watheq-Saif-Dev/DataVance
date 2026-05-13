using DataVance.Application.Common.Interfaces;
using DataVance.Application.DTOs;
using DataVance.Application.SharedAgg.BrancheSystem.Quer;
using DataVance.Application.SharedAgg.BrancheSystem.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.SharedAgg.BrancheSystem.Handler
{

    public class GetBranchesHandler : IRequestHandler<GetBranchesQuery, List<BranchDto>>
    {
        private readonly IBranchService _branchService;
        public GetBranchesHandler(IBranchService branchService) => _branchService = branchService;

        public async Task<List<BranchDto>> Handle(GetBranchesQuery request, CancellationToken ct)
        {
            return await _branchService.GetBranchesByEmailAsync(request.email);

        }
    }
}
