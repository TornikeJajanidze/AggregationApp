using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Application.Models
{
    public class AggregatedData
    {
        public string Region { get; set; }
        public decimal? PPlus { get; set; }
        public decimal? PMinus { get; set; }
    }
}
