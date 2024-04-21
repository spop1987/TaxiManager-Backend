namespace TaxiManagerDomain.Entities
{
    public class Address : BaseEntity
    {
        public string PlaceName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public virtual User User { get; set; }
        public virtual Maintenance Maintenance { get; set; }
        public Guid? MaintenanceId { get; set; }
        public virtual AutoPart AutoPart { get; set; }
        public Guid? AutoPartId { get; set; }
    }
}