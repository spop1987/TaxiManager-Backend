using System.Globalization;
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
                new("Id",  user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new("DriverLicenseExpiredDate", user.DriverLicense.ExpiredDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)),
                new("DriverLicenseCategory", user.DriverLicense.Category)
            };
            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return result;  
        }
    }
}