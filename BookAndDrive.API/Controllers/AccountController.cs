using BookAndDrive.Application.DTOs;
using BookAndDrive.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto userDto)
        {
            var result = await _accountService.RegisterUserAsync(userDto);
            if (!result)
                return BadRequest("Email is used.");

            return Ok("Register Successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto userDto)
        {
            var token = await _accountService.LoginUserAsync(userDto);
            if (token == null)
                return Unauthorized("Incorect login or password.");

            return Ok(new { Token = token });
        }
    }
}
