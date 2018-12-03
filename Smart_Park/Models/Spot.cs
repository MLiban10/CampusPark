using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart_Park.Models
{
    public class ParkingSpot
    {
        public String Id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public int BateryStatus { get; set; }
        public String Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}