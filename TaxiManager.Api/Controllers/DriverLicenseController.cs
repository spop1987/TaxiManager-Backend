using Microsoft.AspNetCore.Mvc;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class DriverLicenseController(IDriverLicenseService driverLicenseService) : BaseApiController
    {
        private readonly IDriverLicenseService _driverLicenseService = driverLicenseService;

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateDriverLicense([FromQuery] Guid driverId, DriverLicenseDto driverLicenseDto)
        {
            return await _driverLicenseService.CreateDriverLicense(driverId, driverLicenseDto);
        }
    }
}