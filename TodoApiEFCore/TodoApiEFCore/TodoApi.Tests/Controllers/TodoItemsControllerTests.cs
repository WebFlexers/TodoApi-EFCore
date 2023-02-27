using Microsoft.AspNetCore.Mvc;
using TodoApi.Data.Entities;
using TodoApi.Data.Entities.DTOs;
using TodoApi.Tests.Mocks;
using TodoApiEFCore.Controllers;

namespace TodoApi.Tests.Controllers
{
    public class TodoItemsControllerTests : BaseTests
    {
        [Fact]
        public async Task GetATodoItem_ShouldGetATodoItem()
        {
            // Preparation
            var dbName = Guid.NewGuid().ToString();
            var context = BuildContext(dbName);
            var identityUtilitiesMock = new IdentityUtilitiesFake();
            var todosController = new TodoItemsController(context, identityUtilitiesMock);


            context.Todos.Add(new Todos()
            {
                Name = "Todo2",
                Description = "This is todo 2",
                UserId = identityUtilitiesMock.GetUserId(null),
                Status = true
            });

            await context.SaveChangesAsync();

            // Testing
            var result = await todosController.GetTodosAll();

            // Verification
            Assert.Equal(2, resultValue.Count());
        }
    }
}
