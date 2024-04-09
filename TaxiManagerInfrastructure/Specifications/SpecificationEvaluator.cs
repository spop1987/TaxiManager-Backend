using Microsoft.EntityFrameworkCore;
using TaxiManagerDomain.Entities;
using TaxiManagerInfrastructure.Interfaces;

namespace TaxiManagerInfrastructure.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQUery, ISpecification<TEntity> spec)
        {
            var query = inputQUery;

            if(spec.Criteria != null)
                query = query.Where(spec.Criteria);
            
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}