namespace TaxiManagerDomain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public virtual User User { get; set; }
    }
}