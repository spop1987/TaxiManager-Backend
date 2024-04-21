namespace TaxiManagerDomain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string VehicleType { get; set; }
        public string Registration { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Nickname { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; } = [];
        public virtual List<Maintenance> Maintenances { get; set; } = [];
    }
}