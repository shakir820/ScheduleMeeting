using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ScheduleMeeting.Data;
using ScheduleMeeting.Helpers;
using ScheduleMeeting.Models;
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



        class cs_post_param
        {
            public List<long> company_ids { get; set; }
            public List<long> country_ids { get; set; }
        }


        [HttpPost]
        public async Task<IActionResult> SearchCompanies(PostData postData)
        {
            try
            {
                var db_com_list = new List<Company>();
                var q_params = JsonConvert.DeserializeObject<cs_post_param>(postData.json_data);
                
                foreach(var item in q_params.company_ids)
                {
                    var db_company = await _context.Companies.FirstOrDefaultAsync(a => a.Id == item);
                    if(db_company != null)
                    {
                        db_com_list.Add(db_company);
                    }
                }
                foreach (var item in q_params.country_ids)
                {
                    var db_company = await _context.Companies.FirstOrDefaultAsync(a => a.CountryId == item);
                    if (db_company != null)
                    {
                        db_com_list.Add(db_company);
                    }
                }

                db_com_list = db_com_list.Distinct().ToList();
                //var db_com_list_temp = db_com_list.ToList();
                //db_com_list = new List<Company>();

                //foreach (var item in db_com_list)
                //{
                //    if(q_params.country_ids.Count > 0)
                //    {
                //        if (!q_params.country_ids.Contains(item.CountryId))
                //        {

                //        }
                //    }
                    
                //}

                var company_list = new List<CompanyModel>();

                foreach(var item in db_com_list)
                {
                    var com = ModelBindingResolver.ResolveCompany(item);
                    var db_city = await _context.Cities.FirstOrDefaultAsync(a => a.Id == item.CityId);
                    if(db_city != null)
                    {
                        com.city = ModelBindingResolver.ResolveCity(db_city);
                    }
                    var db_country = await _context.Countries.FirstOrDefaultAsync(a => a.Id == item.CountryId);
                    if(db_country != null)
                    {
                        com.country = ModelBindingResolver.ResolveCountry(db_country);
                    }
                    com.users = new List<UserModel>();
                    var db_users = await _context.Users.Where(a => a.CompanyID == item.Id).ToListAsync();
                    foreach(var user_item in db_users)
                    {
                         com.users.Add(ModelBindingResolver.ResolveUser(user_item));
                    }
                    company_list.Add(com);
                }

                return new JsonResult(new
                {
                    success = true,
                    error = false,
                    company_list
                });

            }
            catch (Exception ex)
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
