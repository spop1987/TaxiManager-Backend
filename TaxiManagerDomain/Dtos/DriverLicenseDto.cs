namespace TaxiManagerDomain.Dtos
{
    public class DriverLicenseDto
    {
        public string Number { get; set; }
        public string Category { get; set; }
        public DateTime ExpeditionDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}