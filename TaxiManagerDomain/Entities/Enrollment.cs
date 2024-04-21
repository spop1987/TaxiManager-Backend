namespace TaxiManagerDomain.Entities
{
    public class Enrollment : BaseEntity
    {
        public virtual User Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set;  } = null;
        public string Observations { get; set; }
    }
}