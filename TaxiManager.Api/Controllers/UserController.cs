using Microsoft.AspNetCore.Mvc;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class UserController(IUserService userService) : BaseApiController
    {
        private readonly IUserService _userService = userService;

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationDto>> Register(RegisterDto registerDto)
        {
            return await _userService.RegisterAsync(registerDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationDto>> Login(LoginDto loginDto)
        {
            return await _userService.LoginAsync(loginDto);
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userService.FindByEmailAsync(email) != null;
        }
    }
}