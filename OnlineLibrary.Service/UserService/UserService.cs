using Microsoft.AspNetCore.Identity;
using OnlineLibrary.Data.Entities;
using OnlineLibrary.Service.TokenService;
using OnlineLibrary.Service.UserService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }



       
        public async Task<UserDto> Login(LoginDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);

            if (!result.Succeeded)
                throw new Exception("User Not Found");

            return new UserDto
            {
                Id = Guid.Parse(user.Id),
                FirstName = user.firstName,
                Email = user.Email!,
                Token = _tokenService.GenerateToken(user),
            };
        }

        public async Task<UserDto> Register(RegisterDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user is not null)
                return null;
            var appUser = new ApplicationUser
            {
                firstName = input.FirstName,
                Email = input.Email,
                UserName = $"{input.FirstName}{input.LastName}",

            };

            var result = await _userManager.CreateAsync(appUser, input.Password);
            if (!result.Succeeded) throw new Exception(result.Errors.Select(x => x.Description).FirstOrDefault());

            return new UserDto
            {
                Id = Guid.Parse(appUser.Id),
                FirstName = appUser.firstName,
                Email = appUser.Email!,
                Token = _tokenService.GenerateToken(appUser),
            };
        }
    }
}

