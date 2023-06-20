using AggregationApp.Application.Models;

namespace AggregationApp.Api.Services.ElectricityDataService
{
    public interface IElectricityDataService
    {
        Task ProcessElectricityDataAsync();
    }
}
