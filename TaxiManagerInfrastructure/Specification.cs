using System.Linq.Expressions;
using TaxiManagerInfrastructure.Interfaces;

namespace TaxiManagerInfrastructure
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = [];

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}