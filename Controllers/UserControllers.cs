
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Users")]
public class UserController : ControllerBase
{
    IUserService userService = new UserService();


    [HttpPost]
    public bool CreateUser(User user)
    {
        return userService.CreateUser(user);
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return userService.GetUsers();
    }

    [HttpGet("{id}")]
    public User? GetUser(int id)
    {
        return userService.GetUser(id);
    }

    [HttpPut]
    public bool UpdateUser(User user)
    {
        return userService.UpdateUser(user);
    }

    [HttpDelete]
    public bool DeleteUser(int id)
    {
        return userService.DeleteUser(id);
    }
}