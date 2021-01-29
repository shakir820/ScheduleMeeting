using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleMeeting.Data
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScheduleDbContext(serviceProvider.GetRequiredService<DbContextOptions<ScheduleDbContext>>()))
            {
                if (!context.Users.Any())
                {

                    var countries = new List<Country>();
                    countries.Add(new Country
                    {
                        CountryCode = "AF",
                        CountryName = "Afghanistan",
                    });

                    countries.Add(new Country
                    {
                        CountryCode = "BD",
                        CountryName = "Bangladesh",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "AU",
                        CountryName = "Australia",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "IN",
                        CountryName = "India",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "IR",
                        CountryName = "Iran",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "IQ",
                        CountryName = "Iraq",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "CN",
                        CountryName = "China",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "DE",
                        CountryName = "Germany",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "US",
                        CountryName = "United States",
                    });
                    countries.Add(new Country
                    {
                        CountryCode = "GB",
                        CountryName = "United Kingdom",
                    });


                   context.Countries.AddRange(countries.ToArray());
                   context.SaveChanges();

                    var cities = new List<City>();
                    cities.Add(new City
                    {
                        CityName = "Kabul",
                        CountryCode = "AF"
                    });

                    cities.Add(new City
                    {
                        CityName = "Dhaka",
                        CountryCode = "BD"
                    });
                    cities.Add(new City
                    {
                        CityName = "Sydney",
                        CountryCode = "AU"
                    });
                    cities.Add(new City
                    {
                        CityName = "Mumbai",
                        CountryCode = "IN"
                    });
                    cities.Add(new City
                    {
                        CityName = "Tehran",
                        CountryCode = "IR"
                    });
                    cities.Add(new City
                    {
                        CityName = "Baghdad",
                        CountryCode = "IQ"
                    });
                    cities.Add(new City
                    {
                        CityName = "Beijing",
                        CountryCode = "CN"
                    });

                    cities.Add(new City
                    {
                        CityName = "Berlin",
                        CountryCode = "DE"
                    });

                    cities.Add(new City
                    {
                        CityName = "New York",
                        CountryCode = "US"
                    });
                    cities.Add(new City
                    {
                        CityName = "London",
                        CountryCode = "GB"
                    });


                    context.Cities.AddRange(cities.ToArray());
                    context.SaveChanges();



                    var com_types = new List<CompanyType>();
                    com_types.Add(new CompanyType
                    {
                        Name = "Software Company"
                    });

                    com_types.Add(new CompanyType
                    {
                        Name = "Travel Agency"
                    });

                    com_types.Add(new CompanyType
                    {
                        Name = "Car Manufacturing Company"
                    });

                    context.CompanyTypes.AddRange(com_types.ToArray());
                    context.SaveChanges();


                    var companies = new List<Company>();
                    companies.Add(new Company
                    {
                        Address ="Sample Addess. Unknown Address",
                        CityId = cities[8].Id,
                        CountryId = countries[8].Id,
                        EmailId = "company@gmail.com",
                        HowComeToKnow = "From search engine",
                        Name = "Company 1",
                        Phone = "+8801670074271",
                        Status = "New",
                        TypeId = com_types[0].Id,
                        Website = "www.something.com"
                       
                    });


                    companies.Add(new Company
                    {
                        Address = "Sample Addess. Unknown Address",
                        CityId = cities[3].Id,
                        CountryId = countries[3].Id,
                        EmailId = "company@gmail.com",
                        HowComeToKnow = "From search engine",
                        Name = "Company 2",
                        Phone = "+8801670074271",
                        Status = "New",
                        TypeId = com_types[1].Id,
                        Website = "www.something.com"

                    });


                    companies.Add(new Company
                    {
                        Address = "Sample Addess. Unknown Address",
                        CityId = cities[3].Id,
                        CountryId = countries[3].Id,
                        EmailId = "company@gmail.com",
                        HowComeToKnow = "From search engine",
                        Name = "Company 3",
                        Phone = "+8801670074271",
                        Status = "New",
                        TypeId = com_types[1].Id,
                        Website = "www.something.com"

                    });

                    companies.Add(new Company
                    {
                        Address = "Sample Addess. Unknown Address",
                        CityId = cities[8].Id,
                        CountryId = countries[8].Id,
                        EmailId = "company@gmail.com",
                        HowComeToKnow = "From search engine",
                        Name = "Company 4",
                        Phone = "+8801670074271",
                        Status = "New",
                        TypeId = com_types[2].Id,
                        Website = "www.something.com"

                    });

                    companies.Add(new Company
                    {
                        Address = "Sample Addess. Unknown Address",
                        CityId = cities[5].Id,
                        CountryId = countries[5].Id,
                        EmailId = "company@gmail.com",
                        HowComeToKnow = "From search engine",
                        Name = "Company 5",
                        Phone = "+8801670074271",
                        Status = "New",
                        TypeId = com_types[0].Id,
                        Website = "www.something.com"

                    });

                    context.Companies.AddRange(companies.ToArray());
                    context.SaveChanges();



                    var users = new List<User>();
                    users.Add(new User
                    {
                        CompanyID = companies[0].Id,
                        EmailId = "bibhuti@winwebconnect.com",
                        LoginID = "bibhuti@winwebconnect.com",
                        Name = "Bibhuti Bibhaker",
                        Phone = "9323277214",
                        Role = "SuperAdmin",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[0].Id,
                        EmailId = "shakir@winwebconnect.com",
                        LoginID = "shakir@winwebconnect.com",
                        Name = "Shakir Ahmed",
                        Phone = "9323277214",
                        Role = "Admin",
                        Status = "Active",

                    });


                    users.Add(new User
                    {
                        CompanyID = companies[1].Id,
                        EmailId = "saima@winwebconnect.com",
                        LoginID = "saima@winwebconnect.com",
                        Name = "Saima Rahman",
                        Phone = "9323277214",
                        Role = "User",
                        Status = "Active",

                    });


                    users.Add(new User
                    {
                        CompanyID = companies[2].Id,
                        EmailId = "sam@winwebconnect.com",
                        LoginID = "sam@winwebconnect.com",
                        Name = "Sam Watson",
                        Phone = "9323277214",
                        Role = "SuperAdmin",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[2].Id,
                        EmailId = "ruby@winwebconnect.com",
                        LoginID = "ruby@winwebconnect.com",
                        Name = "Ruby Hasan",
                        Phone = "9323277214",
                        Role = "User",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[3].Id,
                        EmailId = "nusrat@winwebconnect.com",
                        LoginID = "nusrat@winwebconnect.com",
                        Name = "Nusrat Hasan",
                        Phone = "9323277214",
                        Role = "User",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[3].Id,
                        EmailId = "bob_tabor@winwebconnect.com",
                        LoginID = "bob_tabor@winwebconnect.com",
                        Name = "Bob Tabor",
                        Phone = "9323277214",
                        Role = "SuperAdmin",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[3].Id,
                        EmailId = "tonny@winwebconnect.com",
                        LoginID = "tonny@winwebconnect.com",
                        Name = "Tonny Kakkar",
                        Phone = "9323277214",
                        Role = "User",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[4].Id,
                        EmailId = "neha@winwebconnect.com",
                        LoginID = "neha@winwebconnect.com",
                        Name = "Neha Kakkar",
                        Phone = "9323277214",
                        Role = "User",
                        Status = "Active",

                    });

                    users.Add(new User
                    {
                        CompanyID = companies[3].Id,
                        EmailId = "tom@winwebconnect.com",
                        LoginID = "tom@winwebconnect.com",
                        Name = "Tom Cruise",
                        Phone = "9323277214",
                        Role = "user",
                        Status = "Active",

                    });


                    context.Users.AddRange(users.ToArray());
                    context.SaveChanges();


                }
            }
        }
    }
}
