using TaxiManagerDomain.Dtos;

namespace TaxiManagerService.Interfaces
{
    public interface IVehicleService
    {
        Task<Guid> AddVehicle(VehicleDto vehicleDto);
        Task<List<VehicleDto>> GetAllVehicles();
    }
}