using TaxiManagerDomain.Dtos;

namespace TaxiManagerService.Interfaces
{
    public interface IAutoPartService
    {
        Task<Guid> AddAutoPart(AutoPartDto autoPartDto);
    }
}