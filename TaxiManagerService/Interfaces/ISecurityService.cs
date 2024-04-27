namespace TaxiManagerService.Interfaces
{
    public interface ISecurityService
    {
        string GenerateJwtToken(string userId, string userEmail, string userType);
        Guid ValidateJwtToken(string token);
        string Hash(string text);
    }
}