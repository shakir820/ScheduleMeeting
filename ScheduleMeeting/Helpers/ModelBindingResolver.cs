using ScheduleMeeting.Models;
using ScheduleMeeting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Helpers
{
    public class ModelBindingResolver
    {
        public static UserModel ResolveUser(User user)
        {
            var u = new UserModel();
            u.accessed = user.Accessed;
            u.company_id = user.CompanyID;
            u.created = user.Created;
            u.email_id = user.EmailId;
            u.id = user.Id;
            u.login_id = user.LoginID;
            u.modified = user.Modified;
            u.name = user.Name;
            u.password = user.Password;
            u.phone = user.Phone;
            u.role = user.Role;
            u.status = user.Status;

            return u;
        }


        public static CompanyModel ResolveCompany(Company company)
        {
            if(company == null)
            {
                return null;
            }

            var c = new CompanyModel();
            c.address = company.Address;
            c.created = company.Created;
            c.email_id = company.EmailId;
            c.how_come_to_know = company.HowComeToKnow;
            c.id = company.Id;
            c.modified = company.Modified;
            c.name = company.Name;
            c.others = company.Others;
            c.phone = company.Phone;
            c.status = company.Status;
            c.website = company.Website;

            return c;
        }


        public static CompanyTypeModel ResolveCompanyType(CompanyType companyType)
        {
            if(companyType == null)
            {
                return null;
            }

            var ct = new CompanyTypeModel();
            ct.id = companyType.Id;
            ct.name = companyType.Name;

            return ct;
        }


        public static CityModel ResolveCity(City city)
        {
            if(city == null)
            {
                return null;
            }

            var c = new CityModel();
            c.city_code = city.CityCode;
            c.city_name = city.CityName;
            c.country_code = city.CountryCode;
            c.id = city.Id;


            return c;

        }


        public static CountryModel ResolveCountry(Country country)
        {
            if(country == null)
            {
                return null;
            }

            var c = new CountryModel();
            c.country_code = country.CountryCode;
            c.country_name = country.CountryName;
            c.id = country.Id;
            c.region_code = country.RegionCode;

            return c;
        }
    }
}
