using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiManager.Api.Attributes;
using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Dtos;
using TaxiManagerService.Interfaces;

namespace TaxiManager.Api.Controllers
{
    public class EnrollmentController : BaseApiController
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
           _enrollmentService = enrollmentService;
        }

        [TaxiManagerAuthorize(UserTypes.ADMIN, UserTypes.DRIVER)]
        [Authorize(policy: "AllowedToDrive")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateEnrollment(EnrollmentDto enrollmentDto)
        {
            return await _enrollmentService.CreateEnrollment(enrollmentDto);
        }
    }
}