using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Helpers;

namespace TaxiManagerDomain.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Identification = user.NationalId.Stringify(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreateDate = user.CreateDate,
                UpdateDate = user.UpdateDate,
                UserTypes =  ToUserTypes(user.Roles),
                Addresses = ToListOfAddressDto(user.Addresses),
                DateOfBirth = user.DateOfBirth,
                DriverLicense = ToDriverLicenseDto(user.DriverLicense)   
            };
        }

        public static User ToUser(this RegisterDto registerDto, string hashedPassword)
        {
            return new User
            {
                NationalId = registerDto.Identification,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                DateOfBirth = registerDto.DateOfBirth.ToDateTime(),
                Email = registerDto.Email,
                Password = hashedPassword,
                Telephone = registerDto.PhoneNumber,
                CreateDate = DateTime.UtcNow
            };
        }

        private static List<AddressDto> ToListOfAddressDto(List<Address> addresses)
        {
            List<AddressDto> listOfAddressDto = [];
            if(addresses.Count == 0)
                return listOfAddressDto;

            addresses.ForEach(a => listOfAddressDto.Add(a.ToAddressDto()));
            return listOfAddressDto;
        }

        private static List<string> ToUserTypes(List<Role> roles)
        {
            List<string> listOfUserType = [];
            if(roles.Count == 0)
                return listOfUserType;
            
            roles.ForEach(r => listOfUserType.Add(r.Name.ToUpper()));
            return listOfUserType;
        }

        private static DriverLicenseDto ToDriverLicenseDto(DriverLicense driverLicense)
        {
            if(driverLicense == null)
                return null;

            var driverLicenseDto = new DriverLicenseDto
            {
                Category = driverLicense.Category,
                Number = driverLicense.Number,
                ExpiredDate = driverLicense.ExpiredDate,
                ExpeditionDate = driverLicense.ExpeditionDate
            };

            return driverLicenseDto;
        }

    }
}