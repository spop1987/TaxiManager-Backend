using TaxiManagerDomain.Dtos;

namespace TaxiManagerService.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Guid> CreateEnrollment(EnrollmentDto enrollmentDto);
    }
}