using System.Security.Claims;

namespace TodoApiEFCore.Utilities;

public static class IdentityUtilities
{
    public static string GetUserId(ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value;
    }
}
