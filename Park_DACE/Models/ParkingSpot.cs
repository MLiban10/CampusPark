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

        public string ToString()
        {
            try
            {
                return string.Format("{0},{1},{2},{3},{4},{5},{6}", Id, Type, Name, Location, BateryStatus, Value, Timestamp);
            }
            catch (Exception)
            {
                string msg = string.Format("'{0}' is an invalid format string", Name);
                throw new ArgumentException(msg);
            }
        }
    }

}