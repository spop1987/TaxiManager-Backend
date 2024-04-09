namespace TaxiManagerDomain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; } = null;
        public DateTime? DeleteDate { get; set; } = null;
    }
}