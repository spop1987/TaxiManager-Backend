namespace TaxiManagerDomain.Dtos
{
    public class AutoPartDto
    {
        public string AutoPartName { get; set; }
        public AddressDto WhereItWasPurchased { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "COP";
        public MaintenanceDto Maintenance { get; set; }
    }
}