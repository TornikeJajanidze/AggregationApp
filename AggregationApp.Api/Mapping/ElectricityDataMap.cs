using AggregationApp.Application.Models;
using CsvHelper.Configuration;

namespace AggregationApp.Api.Mapping
{
    public class ElectricityDataMap : ClassMap<ElectricityData>
    {
        public ElectricityDataMap()
        {
            Map(m => m.Region).Name("TINKLAS");
            Map(m => m.ObjectName).Name("OBT_PAVADINIMAS");
            Map(m => m.ObjectType).Name("OBJ_GV_TIPAS");
            Map(m => m.ObjectNumber).Name("OBJ_NUMERIS");
            Map(m => m.PPlus).Name("P+");
            Map(m => m.PMinus).Name("P-");
            Map(m => m.PL_T).Name("PL_T");
        }
    }
}
