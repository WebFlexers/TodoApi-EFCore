using Microsoft.AspNetCore.Mvc;
using TodoApi.Data.Entities;
using TodoApi.Tests.Mocks;
using TodoApiEFCore.Controllers;

namespace TodoApi.Tests.Controllers;

public class TodosControllerTests : BaseTests
{
    [Fact]
    public async Task GetTodosAll_ShouldReturnAllTodos()
    {
        // Preparation
        var dbName = Guid.NewGuid().ToString();
        var context1 = BuildContext(dbName);
        var context2 = BuildContext(dbName);
        var identityUtilitiesMock = new IdentityUtilitiesFake();
        var todosController = new TodosController(context2, identityUtilitiesMock);

        context1.Todos.Add(new Todos()
        {
            Name = "Todo1",
            Description = "This is todo 1",
            UserId = identityUtilitiesMock.GetUserId(null),
            Status = false
        });

        context1.Todos.Add(new Todos()
        {
            Name = "Todo2",
            Description = "This is todo 2",
            UserId = identityUtilitiesMock.GetUserId(null),
            Status = true
        });

        await context1.SaveChangesAsync();

        // Testing
        var result = await todosController.GetTodosAll();
        var resultValue = ((result.Result as OkObjectResult)!.Value) as IEnumerable<Todos>;

        // Verification
        Assert.Equal(2, resultValue.Count());

        Assert.Equal("Todo1", resultValue.ElementAt(0).Name);
        Assert.Equal("Todo2", resultValue.ElementAt(1).Name);
    }
}