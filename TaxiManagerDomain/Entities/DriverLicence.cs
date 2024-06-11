namespace TaxiManagerDomain.Entities
{
    public class DriverLicense : BaseEntity
    {
        public string Number { get; set; }
        public string Category { get; set; }
        public virtual User Driver { get; set; }
        public Guid? UserId { get; set; }
        public DateTime ExpeditionDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}