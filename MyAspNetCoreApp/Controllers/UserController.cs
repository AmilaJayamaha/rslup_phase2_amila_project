using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyAspNetCoreApp.Models;


[Authorize]
[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private static List<User> users = new List<User>
    {
        new User { Id = 1, Username = "user1", Email = "user1@example.com" },
        new User { Id = 2, Username = "user2", Email = "user2@example.com" }
    };

    [HttpGet]
    public IActionResult GetUsers() => Ok(users);

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = users.Find(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);

        return CreatedAtAction("GetUserById", new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = users.Find(u => u.Id == id);

        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.Username = user.Username;
        existingUser.Email = user.Email;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.Find(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        users.Remove(user);

        return NoContent();
    }
}
