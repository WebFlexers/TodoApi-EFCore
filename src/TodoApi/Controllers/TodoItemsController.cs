using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
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
