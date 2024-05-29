using Microsoft.AspNetCore.Mvc;
using TaxiManager.Api.Attributes;
using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class DriverController(IUserService userService) : BaseApiController
    {
        private readonly IUserService _userService = userService;

        [TaxiManagerAuthorize(UserTypes.ADMIN)]
        [HttpGet("getAllDrivers")]
        public async Task<ActionResult<List<UserDto>>> GetAllDrivers([FromQuery] DriverSpecParamsDto driverSpecParamsDto)
        {
            return await _userService.GetAllDrivers(driverSpecParamsDto);
        }

        [TaxiManagerAuthorize(UserTypes.ADMIN)]
        [HttpGet("getDriver")]
        public async Task<ActionResult<UserDto>> GetDriver([FromQuery] DriverSpecParamsDto driverSpecParamsDto)
        {
            return await _userService.GetDriver(driverSpecParamsDto);
        }
    }
}