using Microsoft.AspNetCore.Authorization;

namespace TaxiManager.Api.Policies.Requirements
{
    public class ValidDriverLicenseRequirement : IAuthorizationRequirement
    {
        public ValidDriverLicenseRequirement(DateTime validDate) =>
            ValidDate = validDate;
        
        public DateTime ValidDate { get; set; }
    }
}