using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Models;

namespace TodoApiEFCore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TodosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("/todos/all")]
    public async Task<ActionResult<IEnumerable<TodosModel>>> GetTodos()
    {
        return await _context.Todos.ToListAsync();
    }

    [HttpGet("/todos/{id}")]
    public async Task<ActionResult<TodosModel>> GetTodos(int id)
    {
        var todosModel = await _context.Todos.FindAsync(id);

        if (todosModel == null)
        {
            return NotFound();
        }

        return todosModel;
    }

    [HttpPost("todos/create")]
    public async Task<ActionResult<TodosModel>> CreateTodosList(TodosModel todos)
    {
        _context.Todos.Add(todos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetToDoItemModel", new { id = todos.TodosId }, todos);
    }

    [HttpPut("/todos/{id}")]
    public IActionResult Update(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("/todos/{id}")]
    public async Task<IActionResult> DeleteToDoItemModel(int id)
    {
        var todos = await _context.Todos.FindAsync(id);
        if (todos == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todos);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
