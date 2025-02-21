using BookAndDrive.Application.DTOs.Account;
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
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            var result = await _accountService.RegisterUserAsync(userDTO);
            if (!result)
                return BadRequest("Email is used.");

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO userDTO)
        {
            var token = await _accountService.LoginUserAsync(userDTO);
            if (token == null)
                return Unauthorized("Incorect email or password.");

            return Ok(new { Token = token });
        }
    }
}
