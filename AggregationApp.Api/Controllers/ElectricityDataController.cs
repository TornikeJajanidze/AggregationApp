using AggregationApp.Api.Services.ElectricityDataService;
using Microsoft.AspNetCore.Mvc;

namespace AggregationApp.Api.Controllers
{
    [ApiController]
    public class ElectricityDataController:ControllerBase
    {
        private readonly IElectricityDataService _electricityDataService;
        public ElectricityDataController(IElectricityDataService electricityDataService)
        {
            _electricityDataService = electricityDataService;
        }
        [HttpPost(ApiEndpoints.ElectricityData.Post)]
        public async Task<IActionResult> ProcessData()
        {
            await _electricityDataService.ProcessElectricityDataAsync();
            return Ok();
        }
    }
}
