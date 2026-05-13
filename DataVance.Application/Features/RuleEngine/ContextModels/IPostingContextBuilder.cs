using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVance.Domain.Common.Models;

namespace DataVance.Application.Features.RuleEngine.ContextModels
{
    public interface IPostingContextBuilder
    {
        string OperationCode { get; }

        Task<Result<PostingContext>> BuildAsync(Guid referenceId, Guid branchId, CancellationToken ct);
    }
}

