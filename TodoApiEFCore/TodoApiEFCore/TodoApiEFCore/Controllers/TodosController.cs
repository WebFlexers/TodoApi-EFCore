using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Authentication;
using TodoApi.Data.Entities;
using TodoApi.Data.Entities.DTOs;
using TodoApiEFCore.Utilities;

namespace TodoApiEFCore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TodosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // List all todosDTO and todo items
    [HttpGet("/todos/all")]
    public async Task<ActionResult<IEnumerable<Todos>>> GetTodosAll()
    {
        var userId = IdentityUtilities.GetUserId(User);

        var allTodos = await _context.Todos
            .AsNoTracking()
            .Where(t => t.UserId.Equals(userId))
            .Include(t => t.TodoItems)
            .ToListAsync();

        return Ok(allTodos);
    }

    // Get a todosDTO list
    [HttpGet("/todos/{id}")]
    public async Task<ActionResult<Todos>> GetTodos(int id)
    {
        var todosModel = await _context.Todos
            .AsNoTracking()
            .Where(t => t.UserId.Equals(IdentityUtilities.GetUserId(User)))
            .Include(t => t.TodoItems)
            .FirstOrDefaultAsync(t => t.Id.Equals(id));

        if (todosModel == null)
        {
            return NotFound();
        }

        return todosModel;
    }

    // Create a new todosDTO list
    [HttpPost("/todos/create")]
    public async Task<ActionResult<Todos>> CreateTodosList([FromBody] CreateTodosDTO todosDTO)
    {
        var todos = new Todos
        {
            Name = todosDTO.Name,
            Description = todosDTO.Description,
            Status = todosDTO.Status,
            UserId = IdentityUtilities.GetUserId(User).ToString(),
        };

        _context.Todos.Add(todos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodos", new { id = todos.Id }, todos);
    }

    // Update a todosDTO list
    [HttpPut("/todos/{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] EditTodosDTO editTodosDto)
    {
        var todosDB = await _context.Todos
            .Where(t => t.UserId.Equals(IdentityUtilities.GetUserId(User)))
            .FirstOrDefaultAsync(todos => todos.Id == id);

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
    [HttpDelete("/todos/{id}")]
    public async Task<IActionResult> DeleteToDoItemModel(int id)
    {
        var todos = await _context.Todos
            .Where(t => t.UserId.Equals(IdentityUtilities.GetUserId(User)))
            .FirstOrDefaultAsync(t => t.Id.Equals(id));

        if (todos == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todos);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
