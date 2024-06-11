using System.Net;

namespace TaxiManagerDomain.Errors
{
    public class TaxiManagerError
    {
        public short ErrorNumber { get; set; }
        public string Message { get; set; }

        public TaxiManagerError(ErrorNumber errorNumber, string message)
        {
            ErrorNumber = (short)errorNumber;
            Message = message;
        }
    }

    public enum ErrorNumber
    {
        ValidationException = HttpStatusCode.BadRequest,
        NotFoundException = HttpStatusCode.NotFound,
        UnauthorizedAccessException = HttpStatusCode.Unauthorized,
        ForbiddenAccessException = HttpStatusCode.Forbidden,
        ApplicationException = HttpStatusCode.InternalServerError,
        DatabaseException = 100
    }
}