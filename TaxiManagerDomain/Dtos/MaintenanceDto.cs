namespace TaxiManagerDomain.Dtos
{
    public class MaintenanceDto
    {
        public long VehicleMileage { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public bool IsRepair { get; set; } = false;
        public AddressDto WhereItWasMade { get; set; }
        public double TotalPrice { get; set; }
        public double LaborPrice { get; set; }
        public VehicleDto Vehicle { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}