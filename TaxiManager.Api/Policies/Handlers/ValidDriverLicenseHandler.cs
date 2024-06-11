using Microsoft.AspNetCore.Authorization;
using TaxiManager.Api.Policies.Requirements;
using TaxiManagerDomain.Errors;
using TaxiManagerDomain.Helpers;

namespace TaxiManager.Api.Policies.Handlers
{
    public class ValidDriverLicenseHandler : AuthorizationHandler<ValidDriverLicenseRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidDriverLicenseRequirement requirement)
        {
            if(context.User.HasClaim(c => c.Type == "DriverLicenseExpiredDate"))
            {
                var driverLicenseExpiredDateClaim = context.User.FindFirst(c => c.Type == "DriverLicenseExpiredDate");
                if(driverLicenseExpiredDateClaim is null)
                    return Task.CompletedTask;
                
                var expiredDate = driverLicenseExpiredDateClaim.Value.ToDateTime();

                if(expiredDate > requirement.ValidDate)
                    context.Succeed(requirement);
                else
                    throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ForbiddenAccessException, $"Driver license expired"));
            }

            return Task.CompletedTask;
        }
    }
}