using TaxiManagerDomain.Dtos;
using TaxiManagerInfrastructure.Specifications;

namespace TaxiManagerInfrastructure.Interfaces
{
    public interface IUserSpecification
    {
        UserSpecification FindUserById(Guid id);
        UserSpecification FindUsersBySpecficications(UserSpecParamsDto userSpecParamsDto);
        UserSpecification FindDriverBySpecification(DriverSpecParamsDto driverSpecParamsDto);
    }
}