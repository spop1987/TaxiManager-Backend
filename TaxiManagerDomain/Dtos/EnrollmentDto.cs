namespace TaxiManagerDomain.Dtos
{
    public class EnrollmentDto
    {
        public DriverDto Driver { get; set; }
        public VehicleDto Vehicle { get; set; }
        public string Observations { get; set; }

    }
}