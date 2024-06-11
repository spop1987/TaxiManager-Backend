namespace TaxiManagerDomain.Entities
{
    public class User : BaseEntity
    {
        public long NationalId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public virtual DriverLicense DriverLicense { get; set; }
        public virtual List<Address> Addresses { get; set; } = [];
        public virtual List<Enrollment> Enrollments { get; set; } = [];
        public virtual List<Role> Roles { get; set; } = [];

    }
}