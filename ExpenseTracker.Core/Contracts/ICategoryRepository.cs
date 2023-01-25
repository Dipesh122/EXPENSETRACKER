using ExpenseTracker.Core.Models;
using ExpneseTracker.Core.ViewModels;

namespace ExpenseTracker.Core.Contracts
{
    public interface ICategoryRepository
    {
        Task<CategoryViewModel> InsertAsync(CategoryViewModel model);
        Task<ICollection<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel?> GetByIdAsync(long id);
        Task<CategoryViewModel> RemoveAsync(long id);
        Task<CategoryViewModel> UpdateAsync(Category  model);
        // IQueryable<CategoryViewModel> GetQueryableLinq();

    }
}