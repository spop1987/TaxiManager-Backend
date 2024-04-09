namespace TaxiManagerService.Interfaces
{
    public interface ISecurityService
    {
        string GenerateJwtToken(string userId, string userEmail);
        Guid ValidateJwtToken(string token);
        string Hash(string text);
    }
}