using DataVance.Application.Common.Interfaces;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.Features.RuleEngine.ContextModels;
using DataVance.Application.Common.Interfaces;
using DataVance.Domain.Finance.Rules.Entities;
using DataVance.Domain.Finance.Rules.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Features.RuleEngine.AccountResolvers
{
    public class AccountResolver
    {
        private readonly IAccountMappingResolver _mappingRepo;
        private readonly IEnumerable<IAccountResolver> _resolvers;


        public AccountResolver(IAccountMappingResolver mappingRepo, IEnumerable<IAccountResolver> resolvers)
        {
            _mappingRepo = mappingRepo;
            _resolvers = resolvers;

        }
        public async Task<Guid> ResolveAccount(PostingContext context, AccountingRuleLine line, Guid? currentReferenceId = null)
        {
            var type = context.PaymentMethod.Method;
            var resolver = _resolvers.FirstOrDefault(r => r.IsMatch(line.AccountSourceType, type));

            if (resolver == null)
                throw new Exception($"Missing reference for {AccountSourceType.Inventory} in Posting Context.");

            return await resolver.ResolveAccount(context, _mappingRepo, currentReferenceId);

            //

            //

        }



        //
        //


        //




    }

}


