using TaxiManagerDomain.Entities;

namespace TaxiManagerInfrastructure.Interfaces
{
    public interface IQueries<T> where T : BaseEntity
    {
        T? GetEntityBySpec(ISpecification<T> spec);

        List<T> GetEntitiesBySpec(ISpecification<T> spec);

        List<T> GetAllEntities();
    }
}