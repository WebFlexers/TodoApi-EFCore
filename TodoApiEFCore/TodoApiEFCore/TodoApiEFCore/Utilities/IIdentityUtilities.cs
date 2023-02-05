using System.Security.Claims;

namespace TodoApiEFCore.Utilities;

public interface IIdentityUtilities
{
    string GetUserId(ClaimsPrincipal user);
}
