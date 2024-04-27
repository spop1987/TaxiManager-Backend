using TaxiManagerDomain.Dtos;

namespace TaxiManagerService.Interfaces
{
    public interface IVehicleService
    {
        Task<Guid> CreateVehicle(VehicleDto vehicleDto);
        Task<List<VehicleDto>> GetAllVehicles();
        Task<VehicleDto> GetVehicleByDriverId(Guid driverId);

    }
}