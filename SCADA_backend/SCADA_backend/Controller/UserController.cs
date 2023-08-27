using Microsoft.AspNetCore.Mvc;
using SCADA_backend.DTO;
using SCADA_backend.Service;

namespace SCADA_backend.Controller

{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok("It works!");

        }

        [HttpPost]
        [Route("login")]

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


        [HttpPost]
        [Route("register")]

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
}