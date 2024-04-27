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
                Identification = user.NationalId.Stringify(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreateDate = user.CreateDate,
                UpdateDate = user.UpdateDate,
                UserType =  user.UserType,
                Addresses = ToListOfAddressDto(user.Addresses)
            };
        }

        public static User ToUser(this RegisterDto registerDto, string hashedPassword)
        {
            return new User
            {
                Email = registerDto.Email,
                Password = hashedPassword,
                UserType = registerDto.UserType.ToUpper(),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Telephone = registerDto.PhoneNumber,
                CreateDate = DateTime.UtcNow,
                NationalId = registerDto.Identification
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
    }
}