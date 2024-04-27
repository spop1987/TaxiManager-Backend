using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Errors;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerService.Interfaces;

namespace TaxiManagerService.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IQueries<User> _queryUsers;
        private readonly IQueries<Vehicle> _queryVehicles;
        private readonly IUserSpecification _userSpecification;
        private readonly IVehicleSpecification _vehicleSpecification;
        private readonly ICommands<Enrollment> _commands;

        public EnrollmentService(IQueries<User> queryUsers,
                                 IQueries<Vehicle> queryVehicles,
                                 IUserSpecification userSpecification,
                                 IVehicleSpecification vehicleSpecification,
                                 ICommands<Enrollment> commands)
        {
            _queryUsers = queryUsers;
            _queryVehicles = queryVehicles;
            _userSpecification = userSpecification;
            _vehicleSpecification = vehicleSpecification;
            _commands = commands;
        }

        public Task<Guid> CreateEnrollment(EnrollmentDto enrollmentDto)
        {
            var specDriver = _userSpecification.FindDriverBySpecification(new DriverSpecParamsDto{Email = enrollmentDto.Driver.Email});
            var driver = _queryUsers.GetEntityBySpec(specDriver) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Usuario no existe"));

            var specVehcile = _vehicleSpecification.FindVehicleByRegistration(enrollmentDto.Vehicle.Registration);
            var vehicle = _queryVehicles.GetEntityBySpec(specVehcile) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "Vehiculo no existe"));

            var newEnrollment = new Enrollment
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.UtcNow,
                Driver = driver,
                Vehicle = vehicle,
                Observations = enrollmentDto.Observations,
                StartDate = DateTime.UtcNow,
            };

            _commands.AddEntity(newEnrollment);

            return Task.FromResult(newEnrollment.Id);    
        }
    }
}