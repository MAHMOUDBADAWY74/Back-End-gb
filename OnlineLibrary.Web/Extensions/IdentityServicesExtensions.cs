using Microsoft.AspNetCore.Identity;
using OnlineLibrary.Data.Contexts;
using OnlineLibrary.Data.Entities;

namespace OnlineLibrary.Web.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApplicationUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<OnlineLibraryIdentityDbContext>();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication();
            return services;

        }
    }
}
//using Microsoft.AspNetCore.Identity;
//using OnlineLibrary.Data.Contexts;
//using OnlineLibrary.Data.Entities;

//namespace OnlineLibrary.Web.Extensions
//{
//    public static class IdentityServicesExtensions
//    {
//        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
//        {
//            services.AddIdentityCore<ApplicationUser>(options =>
//            {
//                // Configure password and lockout policies
//                options.Password.RequireDigit = true;
//                options.Password.RequiredLength = 8;
//                options.Password.RequireNonAlphanumeric = false;
//                options.Password.RequireUppercase = true;
//                options.Password.RequireLowercase = true;
//                options.Lockout.MaxFailedAccessAttempts = 5;
//            })
//            .AddEntityFrameworkStores<OnlineLibraryDbContext>()
//            .AddSignInManager<SignInManager<ApplicationUser>>();

//            services.AddAuthentication(); // Optionally configure schemes here

//            return services;
//        }
//    }
//}
