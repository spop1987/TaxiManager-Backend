namespace TaxiManagerDomain.Errors
{
    public class TaxiManagerException : Exception
    {
        public TaxiManagerException(TaxiManagerError taxiManagementError) : base($"{taxiManagementError.ErrorNumber}, {taxiManagementError.Message}") 
        {
            Error = taxiManagementError;
        }

        public TaxiManagerError Error { get; private set; }
    }
}