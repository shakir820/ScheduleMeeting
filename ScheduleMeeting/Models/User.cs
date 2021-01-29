using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Models
{
    public class User
    {
        public long Id { get; set; }
        public long CompanyID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; }
        public string Accessed { get; set; }
    }
}
