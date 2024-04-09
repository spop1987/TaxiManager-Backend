namespace TaxiManagerDomain.Dtos
{
    public class AuthenticationDto
    {
        public UserDto User { get; set; }
        public string AccessToken { get; set; }
    }
}