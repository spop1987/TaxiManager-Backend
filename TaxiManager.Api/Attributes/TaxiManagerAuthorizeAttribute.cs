using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Errors;

namespace TaxiManager.Api.Attributes
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
            if(user == null || !user.Roles.Any(r => _userTypes.Contains(r.Name)))
                context.Result = new JsonResult(new {message = "User Unauthorized", errorCode = ErrorNumber.UnauthorizedAccessException}){StatusCode = StatusCodes.Status401Unauthorized};
            
        }
    }
}