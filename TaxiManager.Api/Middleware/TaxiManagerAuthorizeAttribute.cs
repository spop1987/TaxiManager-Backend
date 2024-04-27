using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaxiManagerDomain.Entities;

namespace TaxiManager.Api.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TaxiManagerAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _userTypes;

        public TaxiManagerAuthorizeAttribute(params string[] userTypes)
        {
            _userTypes = userTypes;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if(user == null || !_userTypes.Contains(user.UserType))
                context.Result = new JsonResult(new {message = "Unauthorized"}){StatusCode = StatusCodes.Status401Unauthorized};
        }
    }
}