using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Tests;

public class BaseTests
{
    public ApplicationDbContext BuildContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(dbName).Options;
        var dbContext = new ApplicationDbContext(options);
        return dbContext;
    }
}
