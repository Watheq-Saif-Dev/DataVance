using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVance.Domain.Common.Models;

namespace DataVance.Application.Features.RuleEngine.ContextModels
{
    public class PostingContextFactory
    {
        private readonly IEnumerable<IPostingContextBuilder> _builders;

        public PostingContextFactory(IEnumerable<IPostingContextBuilder> builders)
        {
            _builders = builders;
        }

        public async Task<Result<PostingContext>> CreateAsync(
            string operationCode,
            Guid documentId,
            Guid branchId,
            CancellationToken ct)
        {
            var builder = _builders
                .FirstOrDefault(x => x.OperationCode == operationCode);

            if (builder == null)
                return Result<PostingContext>.Failure($"No context builder for {operationCode}");

            return await builder.BuildAsync(documentId, branchId, ct);
        }
    }
}

