[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponse> Login(LoginRequest loginRequest)
    {
        
        var user = _context.Users.FirstOrDefault(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        var token = GenerateToken(user);

        var loginResponse = new LoginResponse
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Token = token
        };

        return loginResponse;
    }

    private string GenerateToken(User user)
    {
       
        return "dummy_token";
    }
}
