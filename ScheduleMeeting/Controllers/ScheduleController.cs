using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleMeeting.Data;
using ScheduleMeeting.Helpers;
using ScheduleMeeting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        ScheduleDbContext _context;
       

        public ScheduleController(ScheduleDbContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> GetDropDownList()
        {

            try
            {
                var db_companies = await _context.Companies.AsNoTracking().ToListAsync();
                var db_countries = await _context.Countries.AsNoTracking().ToListAsync();
                var db_users = await _context.Users.AsNoTracking().ToListAsync();

                var user_list = new List<UserModel>();
                var company_list = new List<CompanyModel>();
                var country_list = new List<CountryModel>();

                foreach (var item in db_companies)
                {
                    company_list.Add(ModelBindingResolver.ResolveCompany(item));
                }

                foreach (var item in db_countries)
                {
                    country_list.Add(ModelBindingResolver.ResolveCountry(item));
                }

                foreach (var item in db_users)
                {
                    user_list.Add(ModelBindingResolver.ResolveUser(item));
                }


                return new JsonResult(new
                {
                    success = true,
                    error = false,
                    user_list,
                    company_list,
                    country_list
                });
            }
            catch(Exception ex)
            {
                return new JsonResult(new
                {
                    success = false,
                    error = true,
                    error_msg = ex.Message
                });
            }

            
        }







    }
}
