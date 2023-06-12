using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Contracts.Responses
{
    public class AggregationAppResponse
    {
        public string Region { get; set; }
        public double SumPPlus { get; set; }
        public double SumPMinus { get; set; }
    }
}
