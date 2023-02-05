using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Entities;
using TodoApi.Data.Entities.DTOs;
using TodoApiEFCore.Utilities;

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

    // Get all todos items of a specified todo list.
    [HttpGet("/todos/{id}/items/all")]
    public async Task<ActionResult<IEnumerable<TodoItem>>> Get(int id)
    {
        var todoItems = await _context.TodoItems
            .AsNoTracking()
            .Where(t => 
                t.UserId.Equals(IdentityUtilities.GetUserId(User)) &&
                t.TodosId.Equals(id)
            )
            .ToListAsync();

        if (todoItems == null)
        {
            return NotFound();
        }

        return Ok(todoItems);
    }


    // Get a todo item
    [HttpGet("/todos/{id}/items/{iid}")]
    public async Task<ActionResult<TodoItem>> GetATodoItem(int id, int iid)
    {
        var todoItem = await _context.TodoItems
            .AsNoTracking()
            .Where(t =>
                t.UserId.Equals(IdentityUtilities.GetUserId(User)) &&
                t.TodosId.Equals(id)
            )
            .FirstOrDefaultAsync(t => t.Id.Equals(iid));

        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(todoItem);
    }

    // Create a new todo item
    [HttpPost("/todos/{id}/items/create")]
    public async Task<ActionResult<TodoItem>> Post(int id, [FromBody] TodoItemDTO itemDTO)
    {
        var todoItem = await _context.Todos
            .Where(t =>
                t.UserId.Equals(IdentityUtilities.GetUserId(User)) &&
                t.Id.Equals(id)
            )
            .Select(t => new TodoItem
            {
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Status = itemDTO.Status,
                UserId = IdentityUtilities.GetUserId(User),
                TodosId = id
            }).FirstOrDefaultAsync();

        if (todoItem == null)
        {
            return NotFound("Wrong Todos Id");
        }

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return Ok(todoItem);
    }

    // Update a todo item
    [HttpPut("/todos/{id}/items/{iid}/update")]
    public async Task<IActionResult> Put(int id, int iid, [FromBody] TodoItemDTO item)
    {
        var todoItem = await _context.TodoItems
            .Where(t =>
                t.UserId.Equals(IdentityUtilities.GetUserId(User)) &&
                t.TodosId.Equals(id)
            ).FirstOrDefaultAsync(t => t.Id.Equals(iid));

        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Name = item.Name;
        todoItem.Description = item.Description;
        todoItem.Status = item.Status;

        await _context.SaveChangesAsync();

        return Ok(todoItem);
    }


    // Delete a todo item
    [HttpDelete("/todos/{id}/items/{iid}")]
    public async Task<IActionResult> DeleteTodoItem(int id, int iid)
    {
        var todoItem = await _context.TodoItems
            .Where(t =>
                t.UserId.Equals(IdentityUtilities.GetUserId(User)) &&
                t.TodosId.Equals(id)
            ).FirstOrDefaultAsync(t => t.Id.Equals(iid));

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}