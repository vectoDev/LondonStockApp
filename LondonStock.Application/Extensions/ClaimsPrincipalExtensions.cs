using System.Security.Claims;

namespace LondonStock.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var value = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(value, out var guid)
                ? guid
                : throw new UnauthorizedAccessException("User ID claim missing or invalid.");
        }

        public static int GetRoleId(this ClaimsPrincipal user)
        {
            var value = user?.FindFirst("role")?.Value;
            return int.TryParse(value, out var roleId)
                ? roleId
                : throw new UnauthorizedAccessException("Role claim missing or invalid.");
        }
    }
}