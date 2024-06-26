using TaxiManagerInfrastructure.Specifications;

namespace TaxiManagerInfrastructure.Interfaces
{
    public interface IVehicleSpecification
    {
        VehicleSpecification FindVehicleByRegistration(string registration);
        VehicleSpecification FindVehicleByDriverId(Guid driverId);
    }
}