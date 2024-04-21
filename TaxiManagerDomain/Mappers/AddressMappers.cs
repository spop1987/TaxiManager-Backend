using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;

namespace TaxiManagerDomain.Mappers
{
    public static class AddressMappers
    {
        public static AddressDto ToAddressDto(this Address address)
        {
            return new AddressDto
            {
                City = address.City,
                State = address.State,
                Street = address.Street,
                Zipcode = address.Zipcode
            };
        }

        public static Address ToAddress(this AddressDto addressDto)
        {
            return new Address
            {
                PlaceName = addressDto.PlaceName,
                City = addressDto.City,
                State = addressDto.State,
                Zipcode = addressDto.Zipcode,
                Street = addressDto.Street
            };
        }
    }
}