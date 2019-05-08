using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class RoomStatus
    {
        public long Id { get; set; }
        public int RoomNumber { get; set; }
        public string UserId { get; set; }
        public float Temperature { get; set; }
        public float AirHumidity { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
