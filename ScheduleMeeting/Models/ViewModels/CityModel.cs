using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models.ViewModels
{
    public class CityModel
    {
        public long id { get; set; }
        public string country_code { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
    }
}
