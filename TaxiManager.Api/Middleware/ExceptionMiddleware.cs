using System.Net;
using System.Text.Json;
using TaxiManager.Api.Errors;
using TaxiManagerDomain.Errors;

namespace TaxiManager.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ConfigureExceptionTypes(ex);

                var response = new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace.ToString());
                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }

        private static int ConfigureExceptionTypes(Exception ex)
        {
            if(ex is TaxiManagerException)
            {
                _ = int.TryParse(ex.Message.Split(",")[0], out int erroCode);
                var httpStatusCode = erroCode switch
                {
                    (int)ErrorNumber.ValidationException => (int)HttpStatusCode.BadRequest,
                    (int)ErrorNumber.NotFoundException => (int)HttpStatusCode.NotFound,
                    (int)ErrorNumber.UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    (int)ErrorNumber.ForbiddenAccessException => (int)HttpStatusCode.Forbidden,
                    (int)ErrorNumber.DatabaseException => (int)HttpStatusCode.InternalServerError,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                return httpStatusCode;
            }
            else
                return (int)HttpStatusCode.InternalServerError;
        }
    }
}