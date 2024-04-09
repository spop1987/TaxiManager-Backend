using TaxiManagerDomain.Entities;
using TaxiManagerInfrastructure.Interfaces;

namespace TaxiManagerInfrastructure
{
    public class Commands<T> : ICommands<T> where T : BaseEntity
    {
        private readonly TaxiManagerContext _context;

        public Commands(TaxiManagerContext context)
        {
            _context = context;
        }

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
}