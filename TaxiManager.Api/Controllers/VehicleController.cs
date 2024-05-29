using Microsoft.AspNetCore.Mvc;
using TaxiManager.Api.Attributes;
using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class VehicleController(IVehicleService vehicleService) : BaseApiController
    {
        private readonly IVehicleService _vehicleService = vehicleService;

        [TaxiManagerAuthorize(UserTypes.ADMIN)]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateVehicle(VehicleDto vehicleDto)
        {
            return await _vehicleService.CreateVehicle(vehicleDto);
        }

        [TaxiManagerAuthorize(UserTypes.ADMIN)]
        [HttpGet("getAllVehicles")]
        public async Task<ActionResult<List<VehicleDto>>> GetAllVehicles()
        {
            return await _vehicleService.GetAllVehicles();
        }

        [TaxiManagerAuthorize(UserTypes.ADMIN, UserTypes.DRIVER)]
        [HttpGet("getVehicleByDriverId")]
        public async Task<ActionResult<VehicleDto>> GetVehicleByDriverId(Guid driverId)
        {
            return await _vehicleService.GetVehicleByDriverId(driverId);
        }
    }
}