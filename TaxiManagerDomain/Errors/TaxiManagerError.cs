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
        ValidationException = 100,
        NotFoundException = 200,
        ApplicationException = 300,
        DatabaseException = 400
    }
}