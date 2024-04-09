using TaxiManagerDomain.Entities;

namespace TaxiManagerInfrastructure.Interfaces
{
    public interface ICommands<T> where T : BaseEntity
    {
        void AddEntity(T entity);
    }
}