using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ScheduleService.BLL.Services.Abstractions;
using ScheduleService.Models.ContractModels;
using ScheduleService.Models.CoreModels;
using System;
using System.Threading.Tasks;

namespace ScheduleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        public readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _authService = authService;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto model)
        {
            var userFromDb = await _authService.LogIn(model);
            if (userFromDb == null)
            {
                return Unauthorized();
            }

            var key = _configuration.GetSection("Auth:Token").Value;
            if (key == null)
            {
                throw new Exception("AuthKey Is Invalid");
            }

            //generate token
            var userToken = await _authService.GenerateToken(userFromDb, key);

            //return MainUserDTo
            return Ok(new
            {
                userToken,
                userFromDb
            });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
