namespace TaxiManagerDomain.Constants
{
    public static class UserTypes
    {
        public const string ADMIN = "ADMIN";
        public const string DRIVER = "DRIVER";
        public const string CUSTOMER = "CUSTOMER";

        public static List<string> ListOfUserTypes {get; private set;} = [ADMIN, DRIVER, CUSTOMER];
    }
}