using AggregationApp.Application.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            AddDbContext(services, connectionString);
            return services;
        }
        public static void AddDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AggregationDbContext>(options =>
             options.UseNpgsql(connectionString));
        }
    }
}
