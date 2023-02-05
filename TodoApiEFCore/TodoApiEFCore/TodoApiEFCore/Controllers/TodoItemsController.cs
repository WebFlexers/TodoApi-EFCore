using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Data.Entities;

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
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return todo.TodoItems.ToList();
    }


    // Get a todo item
    [HttpGet("/todos/{id}/items/{iid}")]
    public async Task<ActionResult<TodoItem>> GetATodoItem(int id, int iid)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        var todoItem = todo.TodoItems.SingleOrDefault(item => item.Id == iid);
        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    // Create a new todo item
    [HttpPost("/todos/{id}/items/create")]
    public async Task<ActionResult<TodoItem>> Post(int id, [FromBody] TodoItem item)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.TodoItems = new List<TodoItem>
        {
            item
        };

        await _context.SaveChangesAsync();

        return CreatedAtAction("GetATodoItem", new { id = id, iid = item.Id }, item);
    }

    // Update a todo item
    [HttpPut("/todos/{id}/items/{iid}/update")]
    public async Task<IActionResult> Put(int id, int iid, [FromBody] TodoItem item)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        var todoItem = todo.TodoItems.SingleOrDefault(i => i.Id == iid);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Name = item.Name;
        todoItem.Status = item.Status;

        await _context.SaveChangesAsync();

        return NoContent();
    }


    // Delete a todo item
    [HttpDelete("/todos/{id}/items/{iid}")]
    public async Task<IActionResult> DeleteTodoItem(int id, int iid)
    {
        var todoList = await _context.Todos.FindAsync(id);
        if (todoList == null)
        {
            return NotFound();
        }

        var todoItem = await _context.TodoItems.FindAsync(iid);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
