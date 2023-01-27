
namespace ExpenseTracker.Core.Contracts
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> InsertAsync(TEntity entity);
        IQueryable<TEntity> GetQueryableLinq();
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> RemoveAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> Pagination();
        // Task<TEntity?> GetEntityAsync(int id);
    }
}
