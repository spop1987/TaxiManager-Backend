using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;

namespace TaxiManagerDomain.Mappers
{
    public static class DriverLicenseMappers
    {
        public static DriverLicense ToDriverLicense(this DriverLicenseDto driverLicenseDto)
        {
            return new DriverLicense
            {
                Number = driverLicenseDto.Number,
                Category = driverLicenseDto.Category,
                ExpeditionDate = driverLicenseDto.ExpeditionDate,
                ExpiredDate = driverLicenseDto.ExpiredDate,
                CreateDate = DateTime.UtcNow    
            };
        }
    }
}