using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Authentication;
using TodoApi.Data.Authentication;
using TodoApi.Data.Entities.DTOs;

namespace TodoApiEFCore.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class RegistrationController : ControllerBase
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration _configuration;


    public RegistrationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        var existingUser = await userManager.FindByNameAsync(model.Username);

        if (existingUser != null)
        {
            return StatusCode(StatusCodes.Status409Conflict, new Response { Status = "Error", Message = "User already exists!" });
        };

        ApplicationUser user = new ApplicationUser
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }

        return Ok(new Response { Status = "Success", Message = "User created successfully" });
    }
}
