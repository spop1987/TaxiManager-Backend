using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService, ISecurityService securityService)
        {
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            if(token != null)
                AttachUserToContext(context, userService, securityService, token);

            await _next(context);
        }

        private static void AttachUserToContext(HttpContext context, IUserService userService, ISecurityService securityService, string token)
        {
            try
            {
                var userId = securityService.ValidateJwtToken(token);

                context.Items["User"] = userService.FindByIdAsync(userId).Result;
            }
            catch 
            {
            }
        }
    }
}