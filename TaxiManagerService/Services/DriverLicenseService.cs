using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Errors;
using TaxiManagerDomain.Mappers;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerService.Interfaces;

namespace TaxiManagerService.Services
{
    public class DriverLicenseService : IDriverLicenseService
    {
        private readonly IQueries<User> _userQueries;
        private readonly IUserSpecification _userSpecification;
        private readonly ICommands<DriverLicense> _driverLicenseCommands;

        public DriverLicenseService(IQueries<User> userQueries, ICommands<DriverLicense> driverLicenseCommands, IUserSpecification userSpecification)
        {
            _driverLicenseCommands = driverLicenseCommands;
            _userQueries = userQueries;
            _userSpecification = userSpecification;
        }
        public async Task<Guid> CreateDriverLicense(Guid driverId, DriverLicenseDto driverLicenseDto)
        {
            var spec = _userSpecification.FindUserById(driverId);
            var user = _userQueries.GetEntityBySpec(spec) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Usuario no existe"));

            var driverLicense = driverLicenseDto.ToDriverLicense();
            driverLicense.Id = Guid.NewGuid();
            driverLicense.CreateDate = DateTime.Now;
            driverLicense.UserId = user.Id;

            try
            {
                _driverLicenseCommands.AddEntity(driverLicense);
                return await Task.FromResult(driverLicense.Id);
            }
            catch 
            {
                throw;
            }
        }
    }
}