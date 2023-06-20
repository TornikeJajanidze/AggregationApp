using AggregationApp.Api.Configuratrions;
using AggregationApp.Api.Services.ElectricityDataService;
using Microsoft.Extensions.Configuration;

namespace AggregationApp.Api
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddSettings(services, configuration);
            AddDataServices(services);
            AddHttpClient(services);

            return services;
        }
        private static void AddSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
        }

        private static void AddDataServices(IServiceCollection services)
        {
            services.AddScoped<IElectricityDataService, ElectiricityDataService>();
        }

        private static void AddHttpClient(IServiceCollection services)
        {
            services.AddHttpClient();
        }
    }
}
