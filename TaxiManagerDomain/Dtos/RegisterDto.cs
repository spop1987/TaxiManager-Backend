namespace TaxiManagerDomain.Dtos
{
    public class RegisterDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserType { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}