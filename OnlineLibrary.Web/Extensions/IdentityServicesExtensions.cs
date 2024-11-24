using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OnlineLibrary.Data.Contexts;
using OnlineLibrary.Data.Entities;
using System.Text;

namespace OnlineLibrary.Web.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration _configuration)
        {
            var builder = services.AddIdentityCore<ApplicationUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<OnlineLibraryIdentityDbContext>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(option =>
                 {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:key"])), 
                     ValidateIssuer = true,
                     ValidIssuer = _configuration["Token:Issuer"],
                     ValidateAudience = false
                 };

                 });
                     return services;

        }
    }
}

