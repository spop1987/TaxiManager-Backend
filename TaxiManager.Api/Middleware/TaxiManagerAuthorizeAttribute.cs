using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Entities;

namespace TaxiManager.Api.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TaxiManagerAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if(user == null || !user.UserType.Equals(UserTypes.ADMIN, StringComparison.CurrentCultureIgnoreCase))
                context.Result = new JsonResult(new {message = "Unauthorized"}){StatusCode = StatusCodes.Status401Unauthorized};
        }
    }
}