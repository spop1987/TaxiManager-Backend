using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;

namespace TaxiManagerService.Interfaces
{
    public interface IUserService
    {
        
        Task<AuthenticationDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthenticationDto> LoginAsync(LoginDto loginDto);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByIdAsync(Guid id);
        Task<List<UserDto>> GetAllDrivers(DriverSpecParamsDto driverSpecParamsDto);
        Task<UserDto> GetDriver(DriverSpecParamsDto driverSpecParamsDto);
    }
}