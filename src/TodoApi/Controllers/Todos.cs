using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Todos : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetSingle(int id)
    {
        throw new NotSupportedException();
    }

    [HttpPost]
    public IActionResult Create()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
