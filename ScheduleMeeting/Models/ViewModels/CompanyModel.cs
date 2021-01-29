using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models.ViewModels
{
    public class CompanyModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public CompanyTypeModel  type { get; set; }
        public string address { get; set; }
        public CityModel city { get; set; }
        public CountryModel country { get; set; }
        public string phone { get; set; }
        public string email_id { get; set; }
        public string website { get; set; }
        public string how_come_to_know { get; set; }
        public string others { get; set; }
        public string status { get; set; }
        public DateTime? created { get; set; } = DateTime.Now;
        public DateTime? modified { get; set; }

        public List<UserModel> users { get; set; }
    }



    public class CompanyTypeModel
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}
