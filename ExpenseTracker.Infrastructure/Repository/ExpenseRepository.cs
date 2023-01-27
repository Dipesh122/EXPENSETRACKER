using AutoMapper;
using ExpenseTracker.Core.Contracts;
using ExpenseTracker.Core.Models;
using ExpneseTracker.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repository
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private readonly IMapper _mapper;
        public ExpenseRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public async Task<ExpenseViewModel> InsertAsync(ExpenseViewModel model)
        {
            var data = _mapper.Map<ExpenseViewModel>(await base.InsertAsync(_mapper.Map<Expense>(model)));
            return data;
        }

        public async Task<ICollection<ExpenseViewModel>> GetAllAsync()
        {
            var entity = base.GetQueryableLinq();
            var result = await _mapper.ProjectTo<ExpenseViewModel>(entity).ToListAsync();
            return result;
        }

        public async Task<ExpenseViewModel?> GetByIdAsync(int id)
        {
            var data = await base.GetByIdAsync(id);
            var result = _mapper.Map<ExpenseViewModel>(data);
            return result;
        }

        // public async Task<ExpenseViewModel> RemoveAsync(int id)
        // {
        //     var data = await base.RemoveAsync(id);
        //     var result = _mapper.Map<ExpenseViewModel>(data);
        //     return result;
        // }

        // public Task<ExpenseViewModel> UpdateAsync(ExpenseViewModel model)
        // {
        //     throw new NotImplementedException();
        // }
    }
}    