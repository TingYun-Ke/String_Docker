using Microsoft.Extensions.DependencyInjection.Extensions;
using WebManager.Services.Interface;
using WebManager.Services;


namespace WebManager.Utility
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Business logic服務
            services.AddScoped<IManagementService, ManagementService>();

            return services;
        }
    }
}
