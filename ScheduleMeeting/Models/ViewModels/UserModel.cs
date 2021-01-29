using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models.ViewModels
{
    public class UserModel
    {
        public long id { get; set; }
        public long company_id { get; set; }
        public string login_id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email_id { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public DateTime? created { get; set; } = DateTime.Now;
        public DateTime? modified { get; set; }
        public string accessed { get; set; }
    }
}
