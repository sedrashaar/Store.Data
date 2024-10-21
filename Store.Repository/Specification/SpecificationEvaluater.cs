using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;


namespace Store.Repository.Specification
{
    public class SpecificationEvaluater<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> specification )
        {
            var query = inputQuery;
            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);

            if (specification.OrderBy is not null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending is not null)
                query = query.OrderByDescending(specification.OrderByDescending);

            if(specification.IsPaginated)
                query = query.Skip(specification.Skip).Take(specification.Take);

            query = specification.Includes.Aggregate(query, (current, inculdeExpression) => current.Include(inculdeExpression));
            return query;
        }
    }
}
