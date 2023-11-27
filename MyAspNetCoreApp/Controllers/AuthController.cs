using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
      
        if (loginRequest.Username == "valid_user" && loginRequest.Password == "valid_password")
        {
            var user = new User { Username = "valid_user", Email = "valid_user@example.com" };

            var token = JwtTokenGenerator.GenerateToken("valid_user");

            return Ok(new { user, token });
        }

        return Unauthorized(new { message = "Invalid credentials" });
    }
}
