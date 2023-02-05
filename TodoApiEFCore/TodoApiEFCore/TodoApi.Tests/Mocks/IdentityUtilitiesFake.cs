using System.Security.Claims;
using TodoApiEFCore.Utilities;

namespace TodoApi.Tests.Mocks;

public class IdentityUtilitiesFake : IIdentityUtilities
{
    private readonly string _userId;

    public IdentityUtilitiesFake()
    {
        _userId = Guid.NewGuid().ToString();
    }

    public string GetUserId(ClaimsPrincipal user)
    {
        return _userId;
    }
}
