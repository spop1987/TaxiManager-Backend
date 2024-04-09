using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;

namespace TaxiManagerDomain.Mappers
{
    public static class VehicleMappers
    {
        public static VehicleDto ToVehicleDeto(this Vehicle vehicle)
        {
            return new VehicleDto
            {
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Nickname = vehicle.Nickname,
                Registration = vehicle.Registration,
                VehicleType = vehicle.VehicleType,
                Year = vehicle.Year
            };
        }
    }
}