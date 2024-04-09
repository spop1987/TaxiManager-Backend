using Microsoft.AspNetCore.Mvc;
using TaxiManager.Api.Middleware;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class VehicleController(IVehicleService vehicleService) : BaseApiController
    {
        private readonly IVehicleService _vehicleService = vehicleService;

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> AddVehicle(VehicleDto vehicleDto)
        {
            return await _vehicleService.AddVehicle(vehicleDto);
        }

        [TaxiManagerAuthorize]
        [HttpGet("getAllVehicles")]
        public async Task<ActionResult<List<VehicleDto>>> GetAllVehicles()
        {
            return await _vehicleService.GetAllVehicles();
        }
    }
}