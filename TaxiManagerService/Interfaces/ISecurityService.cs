using TaxiManagerDomain.Entities;

namespace TaxiManagerService.Interfaces
{
    public interface ISecurityService
    {
        string GenerateJwtToken(User user);
        Guid ValidateJwtToken(string token);
        string Hash(string text);
    }
}