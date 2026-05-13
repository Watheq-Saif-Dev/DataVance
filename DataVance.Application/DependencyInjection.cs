using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using DataVance.Application.Common.Behaviors;
using DataVance.Application.Security.Service;
using DataVance.Application.Common.Interfaces;
using DataVance.Application.AuditSystem.Service;
using DataVance.Application.AlertServices;
using DataVance.Application.SharedAgg.Setting.Interface;

using DataVance.Application.SharedAgg.BrancheSystem.Service;
using DataVance.Application.Features.PurchaseTransactions.Service;

namespace DataVance.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(OutboxEventBehavior<,>));
            });

         
            // Modularized Rule Engine
            services.AddRuleEngineServices();

            return services;
        }
    }
}

