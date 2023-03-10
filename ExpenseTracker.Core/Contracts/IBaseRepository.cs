
using ExpenseTracker.Core.pagination;

namespace ExpenseTracker.Core.Contracts
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> InsertAsync(TEntity entity);
        IQueryable<TEntity> GetQueryableLinq();
        Task<ICollection<TEntity>> GetAllAsync(PaginationFilter filter);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> RemoveAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        // Task<TEntity?> GetEntityAsync(int id);
    }
}
