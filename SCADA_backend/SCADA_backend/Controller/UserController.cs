using Microsoft.AspNetCore.Mvc;
using SCADA_backend.DTO;
using SCADA_backend.Service;

namespace SCADA_backend.Controller;


[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginDTO login)
    {
        try
        {
            UserService.Login(login);
            return Ok("User successfully logged in!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request");
        }
    }
    
    
    [HttpPost("register")]
    public IActionResult Register(LoginDTO user)
    {
        try
        {
            UserService.Register(user);
            return Ok("User successfully registered!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Bad request");
        }
            
    }
    
}