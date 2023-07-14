using Core.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Identity
{
    public class AppIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Moamen",
                    Email = "Moamen@gmail.com",
                    UserName = "Moamen@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Moamen",
                        LastName = "Ashraf",
                        Street = "Faisel",
                        City = "Suez",
                        State = "EG",
                        ZipCode = "45321"

                    }
                };
                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }

    }
}
