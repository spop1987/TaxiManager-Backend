using System.Linq.Expressions;
using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Helpers;
using TaxiManagerInfrastructure.Interfaces;

namespace TaxiManagerInfrastructure.Specifications
{
    public class UserSpecification : Specification<User>, IUserSpecification
    {
        public UserSpecification(Expression<Func<User, bool>> expression) : base(expression)
        {
            AddInclude(u => u.Addresses);
            AddInclude(u => u.Roles);
        }

        public UserSpecification FindDriverBySpecification(DriverSpecParamsDto driverSpecParamsDto)
        {
            if(!string.IsNullOrEmpty(driverSpecParamsDto.FirstName) && !string.IsNullOrEmpty(driverSpecParamsDto.LastName))
                return new UserSpecification(u => u.FirstName.Contains(driverSpecParamsDto.FirstName) && u.LastName.Contains(driverSpecParamsDto.LastName) && u.Roles.Any(r => r.Name == driverSpecParamsDto.UserType));
            
            if(!string.IsNullOrEmpty(driverSpecParamsDto.Email))
                return new UserSpecification(u => u.Email == driverSpecParamsDto.Email && u.Roles.Any(r => r.Name == driverSpecParamsDto.UserType));
            
            if(!string.IsNullOrEmpty(driverSpecParamsDto.Identification))
                return new UserSpecification(u => u.NationalId == driverSpecParamsDto.Identification.ToInt() && u.Roles.Any(r => r.Name == driverSpecParamsDto.UserType));
            
            return new UserSpecification(u => u.Roles.Any(r => r.Name == driverSpecParamsDto.UserType));
        }

        public UserSpecification FindUserById(Guid id)
        {
            return new UserSpecification(u => u.Id == id);
        }

        public UserSpecification FindUsersBySpecficications(UserSpecParamsDto userSpecParamsDto)
        {
            if(!string.IsNullOrEmpty(userSpecParamsDto.FirstName) && !string.IsNullOrEmpty(userSpecParamsDto.LastName))
                return new UserSpecification(u => u.FirstName.Contains(userSpecParamsDto.FirstName) && u.LastName.Contains(userSpecParamsDto.LastName));
            
            if(!string.IsNullOrEmpty(userSpecParamsDto.Email))
                return new UserSpecification(u => u.Email == userSpecParamsDto.Email);
            
            if(!string.IsNullOrEmpty(userSpecParamsDto.Identification))
                return new UserSpecification(u => u.NationalId == userSpecParamsDto.Identification.ToInt());
            
            return new UserSpecification(u => u.Roles.Any(r => r.Name == userSpecParamsDto.UserType));
        }
    }
}