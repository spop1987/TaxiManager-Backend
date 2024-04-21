using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Mappers;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerService.Interfaces;

namespace TaxiManagerService.Services
{
    public class AutoPartService : IAutoPartService
    {
        private readonly ICommands<AutoPart> _commandsAutoPart;
        private readonly ICommands<Address> _commandsAddress;

        public AutoPartService(ICommands<AutoPart> commandsAutoPart, ICommands<Address> commandsAddress)
        {
            _commandsAutoPart = commandsAutoPart;
            _commandsAddress = commandsAddress;
        }
        public Task<Guid> AddAutoPart(AutoPartDto autoPartDto)
        {
            var autopart = autoPartDto.ToAutoPart();
            autopart.Id = Guid.NewGuid();
            autopart.CreateDate = DateTime.Now;
            _commandsAutoPart.AddEntity(autopart);

            var address = autoPartDto.WhereItWasPurchased.ToAddress();
            address.Id = Guid.NewGuid();
            address.AutoPartId = autopart.Id;
            address.CreateDate = DateTime.Now;
            _commandsAddress.AddEntity(address);

            return Task.FromResult(autopart.Id);
        }
    }
}