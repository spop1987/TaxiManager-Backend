using Microsoft.AspNetCore.Mvc;
using TaxiManager.Api.Attributes;
using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class AutoPartController : BaseApiController
    {
        private readonly IAutoPartService _autoPartService;

        public AutoPartController(IAutoPartService autoPartService)
        {
            _autoPartService = autoPartService;
        }

        [TaxiManagerAuthorize(UserTypes.ADMIN)]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> AddAutoPart(AutoPartDto autoPartDto)
        {
            return await _autoPartService.AddAutoPart(autoPartDto);
        }
    }
}