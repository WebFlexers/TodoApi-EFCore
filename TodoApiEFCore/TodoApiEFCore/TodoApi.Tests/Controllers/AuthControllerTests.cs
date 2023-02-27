using Microsoft.AspNetCore.Mvc;
using TodoApi.Data.Entities;
using TodoApi.Tests.Mocks;
using TodoApiEFCore.Controllers;

namespace TodoApi.Tests.Controllers
{
    public class AuthControllerTests : BaseTests
    {
        [Fact]
        public async Task Register_ShouldReturnAllTodos()
        {
            // Preparation
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildContext(dbName);
            var context2 = BuildContext(dbName);
            var identityUtilitiesMock = new IdentityUtilitiesFake();
            var todosController = new TodosController(context2, identityUtilitiesMock);

            // Testing


            // Verification

        }
    }
}
