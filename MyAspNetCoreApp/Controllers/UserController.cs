[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}
public class UserController : ControllerBase
{
    private readonly IEmailService _emailService; 

    public UserController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("forgotpassword")]
    public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
       
        var resetLink = "";

        
        var emailSent = _emailService.SendEmail(request.Email, "Password Reset", $"Click the link to reset your password: {resetLink}");

        if (emailSent)
        {
            return Ok("Password reset link sent successfully.");
        }
        else
        {
            return StatusCode(500, "Failed to send reset link. Please try again later.");
        }
    }
}
