using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    class QuickInfo
    {
        public float AvgTemperature { get; set; }
        public float AvgHumidity { get; set; }
        public bool LeakOfGasStatus { get; set; }
        public float HeatCarrierTemperature { get; set; }
    }
}
