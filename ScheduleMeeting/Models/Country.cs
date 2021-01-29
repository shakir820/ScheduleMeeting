using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models
{
    public class Country
    {
        public long Id { get; set; }
        public string RegionCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
