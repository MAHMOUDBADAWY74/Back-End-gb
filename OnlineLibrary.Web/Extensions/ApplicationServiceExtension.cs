using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Service.HandleResponse;
using OnlineLibrary.Service.TokenService;
using OnlineLibrary.Service.UserService;

namespace OnlineLibrary.Web.Extensions
{
    public  static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
          
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                .Where(model => model.Value?.Errors.Count() > 0)
                                .SelectMany(model => model.Value.Errors)
                                .Select(error => error.ErrorMessage).ToList();

                    var errorRespone = new ValidationErrorResopnse { Errors = errors };

                    return new BadRequestObjectResult(errorRespone);
                };
            });
            return services;

        }
    }
}
