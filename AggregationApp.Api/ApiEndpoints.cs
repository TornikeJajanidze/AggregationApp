namespace AggregationApp.Api
{
    public class ApiEndpoints
    {
        private const string ApiBase = "api";
        public static class AggregatedData
        {
            private const string Base = $"{ApiBase}/AggregatedData";
            public const string GetAll = Base;
        }
        public static class ElectricityData
        {
            private const string Base = $"{ApiBase}/ElectricityData";
            public const string Post = Base;
        }
    }
}
