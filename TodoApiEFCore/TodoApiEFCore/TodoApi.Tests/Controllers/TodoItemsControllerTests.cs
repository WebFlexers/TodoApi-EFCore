using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            var todoItemsController = new TodoItemsController(context, identityUtilitiesMock);

            context.Todos.Add(new Todos()
            {
                Id = 25,
                Name = "Monday",
                Description = "My daily program!",
                UserId = identityUtilitiesMock.GetUserId(null),
                Status = true
            });

            context.Todos.Add(new Todos()
            {
                Id = 32,
                Name = "Tuesday",
                Description = "My daily program!",
                UserId = identityUtilitiesMock.GetUserId(null),
                Status = true
            });

            context.TodoItems.Add(new TodoItem()
            {
                Id = 2,
                Name = "School",
                Description = "Attend classes...",               
                Status = true,
                TodosId = 25,
                UserId = identityUtilitiesMock.GetUserId(null),
            });

            await context.SaveChangesAsync();

            // Testing
            var result = await todoItemsController.GetATodoItem(25, 2);
            var resultValue = ((result.Result as OkObjectResult)!.Value) as TodoItem;
            Debug.WriteLine("Oh hi Mark!");
            Debug.WriteLine(resultValue.Name);

            // Verification
            Assert.True(result != null);
        }

        [Fact]
        public async Task Post_ShouldPostATodoItem()
        {
            // Preparation
            var dbName = Guid.NewGuid().ToString();
            var context = BuildContext(dbName);
            var identityUtilitiesMock = new IdentityUtilitiesFake();
            var todoItemsController = new TodoItemsController(context, identityUtilitiesMock);

            context.Todos.Add(new Todos()
            {
                Id = 25,
                Name = "Monday",
                Description = "My daily program!",
                UserId = identityUtilitiesMock.GetUserId(null),
                Status = true
            });

            await context.SaveChangesAsync();

            var todoItemDTO = new TodoItemDTO()
            {               
                Name = "School",
                Description = "Attend classes...",
                Status = true,
            };

            // Testing
            var result = await todoItemsController.Post(25, todoItemDTO);
            var resultValue = ((result.Result as OkObjectResult)!.Value) as TodoItem;
            Debug.WriteLine("Oh hi Mark!");
            Debug.WriteLine(resultValue.Name);

            // Verification
            Assert.True(result != null);
        }

        [Fact]
        public async Task Put_ShouldUpdateATodoItem()
        {
            // Preparation
            var dbName = Guid.NewGuid().ToString();
            var context = BuildContext(dbName);
            var identityUtilitiesMock = new IdentityUtilitiesFake();
            var todoItemsController = new TodoItemsController(context, identityUtilitiesMock);

            context.Todos.Add(new Todos()
            {
                Id = 25,
                Name = "Monday",
                Description = "My daily program!",
                UserId = identityUtilitiesMock.GetUserId(null),
                Status = true
            });

            context.TodoItems.Add(new TodoItem()
            {
                Id = 2,
                Name = "School",
                Description = "Attend classes...",
                Status = true,
                TodosId = 25,
                UserId = identityUtilitiesMock.GetUserId(null),
            });

            await context.SaveChangesAsync();

            var todoItemDTO = new TodoItemDTO()
            {
                Name = "School",
                Description = "Attend only History class!",
                Status = true,
            };

            // Testing
            //var resultGetToDoItemBefore = await todoItemsController.GetATodoItem(25, 2);
            var result = await todoItemsController.Put(25, 2, todoItemDTO);
            //var resultGetToDoItemAfter = await todoItemsController.GetATodoItem(25, 2);

            //var resultValueBefore = ((resultGetToDoItemBefore.Result as OkObjectResult)!.Value) as TodoItem;
            //var resultValueAfter = ((resultGetToDoItemAfter.Result as OkObjectResult)!.Value) as TodoItem;
            Debug.WriteLine("Oh hi Mark!");
            //Debug.WriteLine("Before: " + resultValueBefore.Description);
            //Debug.WriteLine("After: " + resultValueAfter.Description);

            // Verification
            Assert.True(result != null);
        }

        [Fact]
        public async Task DeleteTodoItem_ShouldDeleteTodoItem()
        {
            // Preparation
            var dbName = Guid.NewGuid().ToString();
            var context = BuildContext(dbName);
            var identityUtilitiesMock = new IdentityUtilitiesFake();
            var todoItemsController = new TodoItemsController(context, identityUtilitiesMock);

            context.Todos.Add(new Todos()
            {
                Id = 25,
                Name = "Monday",
                Description = "My daily program!",
                UserId = identityUtilitiesMock.GetUserId(null),
                Status = true
            });

            context.TodoItems.Add(new TodoItem()
            {
                Id = 2,
                Name = "School",
                Description = "Attend classes...",
                Status = true,
                TodosId = 25,
                UserId = identityUtilitiesMock.GetUserId(null),
            });

            await context.SaveChangesAsync();


            // Testing
            var result = await todoItemsController.DeleteTodoItem(25, 2);
            var resultStatusCode = result as NoContentResult;
            Debug.WriteLine("Oh hi Mark!");

            // Verification
            Assert.Equal(204, resultStatusCode.StatusCode);
        }
    }
}
