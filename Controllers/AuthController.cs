using CarAppDotNetApi.Controllers.BaseController;
using CarAppDotNetApi.Dtos;
using CarAppDotNetApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarAppDotNetApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("Auth")]
    public class AuthController : BaseCarAppController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            return Ok(_authService.AttemptToLogin(loginDto));
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            return Created(HttpContext.Request.Path, _authService.AttemptRegister(registerDto));
        }

        [HttpPost("RefreshToken")]
        public IActionResult RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            return Ok(_authService.RefreshToken(refreshTokenDto));
        }
    }
}