using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Errors;
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
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                transaction.Commit();
                transaction.Dispose();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                transaction.Dispose();
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.DatabaseException, $"Message: {ex.Message}, InnerException Message: {ex?.InnerException?.Message}"));
            }
            
        }
    }
}