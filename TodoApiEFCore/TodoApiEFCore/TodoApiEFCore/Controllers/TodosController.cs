using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Entities;
using TodoApi.Data.Entities.DTOs;

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

    // List all todosDTO and todo items
    [HttpGet("/todosDTO/all")]
    public async Task<ActionResult<IEnumerable<Todos>>> GetTodosAll()
    {
        var allTodos = await _context.Todos.ToListAsync();
        
        
        return Ok(allTodos);

    }

    // Get a todosDTO list
    [HttpGet("/todosDTO/{id}")]
    public async Task<ActionResult<Todos>> GetTodos(int id)
    {
        var todosModel = await _context.Todos.FindAsync(id);

        if (todosModel == null)
        {
            return NotFound();
        }

        return todosModel;
    }

    // Create a new todosDTO list
    [HttpPost("/todosDTO/create")]
    public async Task<ActionResult<Todos>> CreateTodosList([FromBody] CreateTodosDTO todosDTO)
    {
        var todos = new Todos
        {
            Name = todosDTO.Name,
            Description = todosDTO.Description,
            Status = todosDTO.Status,
        };

        _context.Todos.Add(todos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodos", new { id = todos.Id }, todos);
    }

    // Update a todosDTO list
    [HttpPut("/todosDTO/{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] EditTodosDTO editTodosDto)
    {
        var todosDB = await _context.Todos.FirstOrDefaultAsync(todos => todos.Id == id);

        if (todosDB == null)
        {
            return NotFound();
        }

        todosDB.Id = id;
        todosDB.Name = editTodosDto.Name;
        todosDB.Description = editTodosDto.Description;
        todosDB.Status = editTodosDto.Status;

        await _context.SaveChangesAsync();
        return Ok(todosDB);
    }

    // Delete a todosDTO list and its items
    [HttpDelete("/todosDTO/{id}")]
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

    private bool TodoExists(int id)
    {
        return _context.Todos.Any(e => e.Id == id);
    }
}
