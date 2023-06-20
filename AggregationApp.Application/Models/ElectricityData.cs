using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Application.Models
{
    public class ElectricityData
    {
        public string? Region { get; set; } // TINKLAS
        public string? ObjectName { get; set; } // OBT_PAVADINIMAS
        public string? ObjectType { get; set; } // OBJ_GV_TIPAS
        public string? ObjectNumber { get; set; } // OBJ_NUMERIS
        public decimal? PPlus { get; set; }
        public decimal? PMinus { get; set; }
        public DateTime PL_T { get; set; }
       
    }
}
