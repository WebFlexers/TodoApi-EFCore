﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Data.Entities;

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

    // List all todos and todo items
    [HttpGet("/todos/all")]
    public async Task<ActionResult<IEnumerable<Todos>>> GetTodosAll()
    {
        var allTodos = await _context.Todos.ToListAsync();
        
        
        return Ok(allTodos);

    }

    // Get a todos list
    [HttpGet("/todos/{id}")]
    public async Task<ActionResult<Todos>> GetTodos(int id)
    {
        var todosModel = await _context.Todos.FindAsync(id);

        if (todosModel == null)
        {
            return NotFound();
        }

        return todosModel;
    }

    // Create a new todos list
    [HttpPost("/todos/create")]
    public async Task<ActionResult<Todos>> CreateTodosList([FromBody] Todos todos)
    {
        _context.Todos.Add(todos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTodos", new { id = todos.Id }, todos);
    }

    // Update a todos list
    [HttpPut("/todos/{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todos todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        _context.Entry(todo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // Delete a todos list and its items
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

    private bool TodoExists(int id)
    {
        return _context.Todos.Any(e => e.Id == id);
    }
}
