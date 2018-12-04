using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_DACE.Models
{
    class Configuration
    {
        public String connectionType { get; set; }
        public String endpoint { get; set; }
        public int id { get; set; }
        public String description { get; set; }
        public int numberOfSpots { get; set; }
        public String operatingHours { get; set; }
        public int numberOfSpecialSpots { get; set; }
        public String geoLocationFile { get; set; }
    }
}