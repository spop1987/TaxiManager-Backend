using TaxiManagerDomain.Dtos;

namespace TaxiManagerService.Interfaces
{
    public interface IDriverLicenseService
    {
        Task<Guid> CreateDriverLicense(Guid driverId, DriverLicenseDto driverLicenseDto);
    }
}