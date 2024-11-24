using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Service.UserService.Dtos;
using OnlineLibrary.Service.UserService;
using OnlineLibrary.Service.HandleResponse;

namespace OnlineLibrary.Web.Controllers
{
  
    public class AccountController :BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto input)
        {
            var user = await _userService.Login(input);
            if (user == null)
                return BadRequest(new UserException(400, "Email Does Not Found"));
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto input)
        {
            var user = await _userService.Register(input);
            if (user == null)
                return BadRequest(new UserException(400, "Email Already Exists"));
            return Ok(user);
        }

        

    }
}


