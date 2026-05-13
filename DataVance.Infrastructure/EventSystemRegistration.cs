using DataVance.Application.Security.Service;
using DataVance.Infrastructure.EventManagement.BackgroundServices;
using DataVance.Infrastructure.EventManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DataVance.Infrastructure
{
    public static class EventSystemRegistration
    {
        public static IServiceCollection AddEventSystemServices(this IServiceCollection services)
        {
            services.AddHostedService<OutboxProcessor>();
            services.AddScoped<IOperationEventExecutor, OperationEventExecutor>();
            services.AddScoped<IEventAuthorizationService, EventAuthorizationService>();
            
            return services;
        }
    }
}
