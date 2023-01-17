using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        throw new NotImplementedException();
    }
}
