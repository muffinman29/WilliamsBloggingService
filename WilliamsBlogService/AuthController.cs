using Microsoft.AspNetCore.Mvc;

namespace WilliamsBlogService
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var user = new Business.User();
            if (await user.AuthenticateUser(request.Username, request.Password))
            {
                var token = _jwtTokenService.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

}
