using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models
{
    public class City
    {
        public long Id { get; set; }
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }

    }
}
