
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data.Contexts;
using OnlineLibrary.Data.Entities;

namespace OnlineLibrary.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OnlineLibraryIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            //{
            //    config.Password.RequiredUniqueChars = 1;
            //    config.Password.RequireDigit = true;
            //    config.Password.RequireLowercase = true;
            //    config.Password.RequireUppercase = true;
            //    config.Password.RequireNonAlphanumeric = true;
            //    config.Password.RequiredLength = 6;
            //    config.User.RequireUniqueEmail = true;
            //    config.Lockout.AllowedForNewUsers = true;
            //    config.Lockout.MaxFailedAccessAttempts = 3;
            //    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);

            //}).AddEntityFrameworkStores<OnlineLibraryDbContext>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
