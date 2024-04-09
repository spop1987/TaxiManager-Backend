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
    }
}