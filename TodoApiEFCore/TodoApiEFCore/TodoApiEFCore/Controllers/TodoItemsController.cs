using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;

namespace TodoApiEFCore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public TodoItemsController(ApplicationDbContext context)
    {
        _context = context;
    }



    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Post()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
