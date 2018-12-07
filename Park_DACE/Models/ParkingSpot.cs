using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park_DACE.Models
{
    public class ParkingSpot
    {
        public String Id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public int BateryStatus { get; set; }
        public Boolean Value { get; set; }
        public String Timestamp { get; set; }
    }
    /*
    public override string ToString()
    {
        return "";
    }
    */
}