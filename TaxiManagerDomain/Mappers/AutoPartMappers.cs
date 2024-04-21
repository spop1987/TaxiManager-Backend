using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Shared;

namespace TaxiManagerDomain.Mappers
{
    public static class AutoPartMappers
    {
        public static AutoPart ToAutoPart(this AutoPartDto autoPartDto)
        {
            return new AutoPart
            {
                Id = Guid.NewGuid(),
                AutoPartName = autoPartDto.AutoPartName,
                Price = new Money(autoPartDto.Price, new Currency(autoPartDto.Currency))
            };
        }
    }
}