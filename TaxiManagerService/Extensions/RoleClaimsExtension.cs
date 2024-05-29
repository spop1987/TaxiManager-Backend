using System.Security.Claims;
using TaxiManagerDomain.Entities;

namespace TaxiManagerService.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new("id",  user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
            };
            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return result;  
        }
    }
}