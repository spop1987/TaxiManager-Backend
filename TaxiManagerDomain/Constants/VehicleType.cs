namespace TaxiManagerDomain.Constants
{
    public static class VehicleType
    {
        public const string TAXI = "TAXI";

        public static List<string> ListOfVehicleTypes {get; private set;} = [TAXI];
    }
}