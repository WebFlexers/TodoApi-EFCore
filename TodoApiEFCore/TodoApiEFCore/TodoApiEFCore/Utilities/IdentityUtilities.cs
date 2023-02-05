using System.Security.Claims;

namespace TodoApiEFCore.Utilities;

public class IdentityUtilities : IIdentityUtilities
{
    public string GetUserId(ClaimsPrincipal user)
    {
        return user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value;
    }
}