using AggregationApp.Api.Configuratrions;
using AggregationApp.Api.Services.ElectricityDataService;
using Microsoft.Extensions.Configuration;

namespace AggregationApp.Api
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.AddScoped<IElectricityDataService, ElectiricityDataService>();
            services.AddHttpClient();
            return services;
        }
    }
}
