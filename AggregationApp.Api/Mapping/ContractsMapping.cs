using AggregationApp.Application.Models;
using AggregationApp.Contracts.Responses;

namespace AggregationApp.Api.Mapping
{
    public static class ContractsMapping
    {
        public static List<AggregationAppResponse> MapToResponse(this List<AggregatedData> aggregatedData)
        {
            List<AggregationAppResponse> response = new List<AggregationAppResponse>();
            foreach(var item in aggregatedData)
            {
                var AggregatedAppResponse = new AggregationAppResponse()
                {
                    Region = item.Region,
                    SumPPlus = (double)item.PPlus,
                    SumPMinus = (double)item.PMinus,
                };
                response.Add(AggregatedAppResponse);
            }
            return response;
        }
    }
}
