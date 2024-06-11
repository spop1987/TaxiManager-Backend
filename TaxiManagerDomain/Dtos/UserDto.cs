namespace TaxiManagerDomain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> UserTypes { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DriverLicenseDto DriverLicense { get; set; }
        public List<AddressDto> Addresses {get; set;}
    }
}