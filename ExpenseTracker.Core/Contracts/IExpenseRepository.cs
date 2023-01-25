using ExpenseTracker.Core.Models;
using ExpneseTracker.Core.ViewModels;

namespace ExpenseTracker.Core.Contracts
{
    public interface IExpenseRepository
    {
        Task<ExpenseViewModel> InsertAsync(ExpenseViewModel model);
        Task<ICollection<ExpenseViewModel>> GetAllAsync();
        Task<ExpenseViewModel?> GetByIdAsync(int id);
        // Task<ExpenseViewModel> RemoveAsync(int id);
        // Task<ExpenseViewModel> UpdateAsync(ExpenseViewModel model);
        // IQueryable<Expense> GetQueryableLinq();

    }
}