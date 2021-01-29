using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models.ViewModels
{
    public class CountryModel
    {
        public long id { get; set; }
        public string region_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }

    }
}
