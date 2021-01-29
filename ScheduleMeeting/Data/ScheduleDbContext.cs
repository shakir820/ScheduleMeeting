using Microsoft.EntityFrameworkCore;
using ScheduleMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Data
{
    public class ScheduleDbContext: DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options)
        : base(options)
        {

        }


        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }

    }
}
