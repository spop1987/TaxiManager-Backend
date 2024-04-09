using TaxiManagerDomain.Entities;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerInfrastructure.Specifications;

namespace TaxiManagerInfrastructure
{
    public class Queries<T> : IQueries<T> where T : BaseEntity
    {
        private readonly TaxiManagerContext _context;

        public Queries(TaxiManagerContext context)
        {
            _context = context;
        }
        
        public User? FindUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public List<T> GetAllEntities()
        {
            return _context.Set<T>().AsQueryable().ToList();
        }

        public List<T> GetEntitiesBySpec(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        public T? GetEntityBySpec(ISpecification<T> spec)
        {
            var algo = ApplySpecification(spec);
            var response = algo.ToList();
            return response.FirstOrDefault();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}