using TaxiManagerDomain.Entities;
using TaxiManagerInfrastructure.Interfaces;

namespace TaxiManagerInfrastructure.Specifications
{
    public class VehicleSpecification : Specification<Vehicle>, IVehicleSpecification
    {
        public VehicleSpecification(string registration) : base(v => v.Registration == registration)
        {
            AddInclude(v => v.Enrollments);
        }

        public VehicleSpecification FindVehicleByRegistration(string registration)
        {
            return new VehicleSpecification(registration);
        }
    }
}