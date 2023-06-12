using AggregationApp.Api.Mapping;
using AggregationApp.Application.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
a
namespace AggregationApp.Api.Controllers
{
    [ApiController]
    public class AggregatedDataController : ControllerBase
    {
        private readonly AggregationDbContext _context;
        public AggregatedDataController(AggregationDbContext context)
        {
            _context = context;
        }
        [HttpGet(ApiEndpoints.AggregatedData.GetAll)]
        public async Task<IActionResult> GetData()
        {
            var data =await _context.AggregatedData.ToListAsync();
            return Ok(data.MapToResponse());
        }
    }
}
