using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult Signup()
    {
        throw new NotImplementedException();
    }
}
