using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Errors;
using TaxiManagerDomain.Mappers;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerService.Interfaces;

namespace TaxiManagerService.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ICommands<Vehicle> _command;
        private readonly IQueries<Vehicle> _queryVehicle;
        private readonly IVehicleSpecification _vehicleSpecification;

        public VehicleService(ICommands<Vehicle> command, IQueries<Vehicle> queryVehicle, IVehicleSpecification vehicleSpecification)
        {
            _command = command;
            _queryVehicle = queryVehicle;
            _vehicleSpecification = vehicleSpecification;
        }

        public async Task<Guid> CreateVehicle(VehicleDto vehicleDto)
        {
            if (IsVehicleValid(vehicleDto))
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Todos los campos son obligatorios (Marca, Modelo, Placa y Año)."));

            if (!VehicleType.ListOfVehicleTypes.Contains(vehicleDto.VehicleType.ToUpper())) 
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Tipo de vehiculo invalido"));
            
            var spec = _vehicleSpecification.FindVehicleByRegistration(vehicleDto.Registration);
            
            var vehicleInDb = _queryVehicle.GetEntityBySpec(spec);

            if(vehicleInDb != null)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "La placa del vehiculo esta en uso"));

            var newVehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Brand = vehicleDto.Brand,
                Model = vehicleDto.Model,
                Nickname = vehicleDto.Nickname,
                Year = vehicleDto.Year,
                VehicleType = vehicleDto.VehicleType,
                Registration = vehicleDto.Registration,
                CreateDate = DateTime.UtcNow
            };

            _command.AddEntity(newVehicle);

            return await Task.FromResult(newVehicle.Id);
        }

        public async Task<List<VehicleDto>> GetAllVehicles()
        {
            var listOfVehicles = _queryVehicle.GetAllEntities();

            if(listOfVehicles.Count == 0)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "No hay vehiculos registrados"));

            var listOfVehicleDto = new List<VehicleDto>();

            listOfVehicles.ForEach(v => listOfVehicleDto.Add(v.ToVehicleDeto()));

            return await Task.FromResult(listOfVehicleDto);
        }

        public async Task<VehicleDto> GetVehicleByDriverId(Guid driverId)
        {
            var spec = _vehicleSpecification.FindVehicleByDriverId(driverId);
            var vehicle = _queryVehicle.GetEntityBySpec(spec) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "No hay vehiculo asociado al conductor"));
            return await Task.FromResult(vehicle.ToVehicleDeto());
        }

        private bool IsVehicleValid(VehicleDto vehicleDto)
        {
            return string.IsNullOrEmpty(vehicleDto.Brand) ||
                            string.IsNullOrEmpty(vehicleDto.Model) ||
                            string.IsNullOrEmpty(vehicleDto.Year) ||
                            string.IsNullOrEmpty(vehicleDto.Registration);
        }
    }
}