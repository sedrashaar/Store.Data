using Store.Data.Entities;
using Store.Repository.Specification;


namespace Store.Repository.Interfaces
{
    
    public interface IGenericRepository<TEntity ,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey? id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync();
        Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity>specification);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specification);
        Task<int> GetCountSpecificationAsync(ISpecification<TEntity> specification);
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);  
    }
}
