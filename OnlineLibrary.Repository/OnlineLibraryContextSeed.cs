using Microsoft.AspNetCore.Identity;
using OnlineLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Repository
{
    public class OnlineLibraryContextSeed
    {
        public static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    firstName = "Shimaa",
                    LastName = "Nabil",
                    Email = "Shimaa@gmail.com",
                    Gender = "F",
                    DateOfBirth = DateOnly.Parse("2024-11-23"),
                    Address = new Address
                    {
                        FirstName = "Shimaa",
                        City = "Maadi",
                        State = "Cairo",
                        Street = "105",
                        PostalCode = "123456"
                    }

                };
                Console.WriteLine("Users exist in database: " + userManager.Users.Any());

                await userManager.CreateAsync(user, "Password123!");
            }
        }

    }
}
