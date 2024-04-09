namespace TaxiManagerDomain.Entities
{
    public class Enrollment
    {
        public Guid Id { get; set; }
        public User Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set;  } = null;
    }
}