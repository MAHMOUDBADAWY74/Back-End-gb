using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineLibrary.Data.Contexts;
using System.IO;

namespace OnlineLibrary.Data.Contexts
{
    public class OnlineLibraryIdentityDbContextFactory : IDesignTimeDbContextFactory<OnlineLibraryIdentityDbContext>
    {
        public OnlineLibraryIdentityDbContext CreateDbContext(string[] args)
        {
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName) 
                .AddJsonFile("OnlineLibrary.Web/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure DbContextOptions with the connection string
            var optionsBuilder = new DbContextOptionsBuilder<OnlineLibraryIdentityDbContext>();
            optionsBuilder.UseSqlServer(connectionString); 

            return new OnlineLibraryIdentityDbContext(optionsBuilder.Options);
        }
    }
}

