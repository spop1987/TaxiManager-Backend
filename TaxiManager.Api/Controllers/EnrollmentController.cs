using Microsoft.AspNetCore.Mvc;
using TaxiManager.Api.Middleware;
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

        [TaxiManagerAuthorize(UserTypes.ADMIN)]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateEnrollment(EnrollmentDto enrollmentDto)
        {
            return await _enrollmentService.CreateEnrollment(enrollmentDto);
        }
    }
}