namespace TaxiManagerDomain.Entities
{
    public class User : BaseEntity
    {
        public int NationalId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Telephone { get; set; }
        public virtual List<Address> Addresses { get; set; } = [];
        public virtual List<Enrollment> Enrollments { get; set; } = [];
    }
}