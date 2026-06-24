using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.identity;

namespace Talabat.DAL.identity
{
    public static class AppIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {

                var user = new AppUser()
                {
                    DisplayName = "Ali Kamal",
                    UserName = "AliKamal04",
                    Email = "ali123kama12@gmail.com",
                    PhoneNumber = "01001877625",
                    Address = new Address()
                    {
                        FirstName = "Ali",
                        LastName = "kamal",
                        Country = "Egypt",
                        City = "menofiya",
                        Street = "10 Paris St.",
                        ZipCode = "23423"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
