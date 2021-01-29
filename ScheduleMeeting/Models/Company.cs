using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models
{
    public class Company
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public long TypeId { get; set; }
        public string Address { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public string HowComeToKnow { get; set; }
        public string Others { get; set; }
        public string Status { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; }
    }



    public class CompanyType
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
