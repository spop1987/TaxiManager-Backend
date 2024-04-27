using System.Linq.Expressions;
using TaxiManagerDomain.Entities;
using TaxiManagerInfrastructure.Interfaces;

namespace TaxiManagerInfrastructure.Specifications
{
    public class VehicleSpecification : Specification<Vehicle>, IVehicleSpecification
    {
        public VehicleSpecification(Expression<Func<Vehicle, bool>> expression) : base(expression)
        {
            AddInclude(v => v.Enrollments);
        }

        public VehicleSpecification FindVehicleByDriverId(Guid driverId)
        {
            return new VehicleSpecification(v => v.Enrollments.Any(e => e.Driver.Id == driverId && e.EndDate == null));
        }

        public VehicleSpecification FindVehicleByRegistration(string registration)
        {
            return new VehicleSpecification(v => v.Registration == registration);
        }
    }
}