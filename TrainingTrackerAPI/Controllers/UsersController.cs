using Microsoft.AspNetCore.Mvc;

namespace TrainingTrackerAPI.Controllers;

    [ApiController]
    [Route("api/[controller]/[action]")]
    
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = new List<User>
        {
            new User { Id = 1, Name = "Anna", Email = "anna.andersson@gmail.com" }
        };
        return Ok(users);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}