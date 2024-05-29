namespace TaxiManagerDomain.Constants
{
    public static class UserTypes
    {
        public const string ADMIN = "ADMIN";
        public const string DRIVER = "DRIVER";
        public const string OWNER = "OWNER";
        public const string MANAGER = "MANAGER";

        public static List<string> ListOfUserTypes {get; private set;} = [ADMIN, DRIVER, OWNER, MANAGER];
    }
}