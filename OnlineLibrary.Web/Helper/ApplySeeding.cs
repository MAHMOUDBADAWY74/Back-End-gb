using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data.Contexts;
using OnlineLibrary.Data.Entities;
using OnlineLibrary.Repository;

namespace OnlineLibrary.Web.Helper
{
    public class ApplySeeding
    {

        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerfactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<OnlineLibraryIdentityDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    await OnlineLibraryContextSeed.SeedUserAsync(userManager);


                 
                    await context.Database.MigrateAsync();

                    await OnlineLibraryContextSeed.SeedUserAsync(userManager);

                }
                catch (Exception ex)
                {
                    
                    var logger = loggerfactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);


                }
                

            }
        }

    }
}


