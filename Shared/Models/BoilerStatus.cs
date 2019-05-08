using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class BoilerStatus
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public float HeatCarrierTemperature { get; set; }
        public bool LeakOfGasSatus { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
