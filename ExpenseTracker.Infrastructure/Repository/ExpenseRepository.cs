using AutoMapper;
using ExpenseTracker.Core.Contracts;
using ExpenseTracker.Core.Models;
using ExpenseTracker.Core.pagination;
using ExpneseTracker.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repository
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbcontext;
        public ExpenseRepository(AppDbContext context, IMapper mapper, AppDbContext dbContext) : base(context, mapper)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
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

        public async Task<ICollection<Expense>> Pagination(PaginationFilter filter)
        {
            var pagination = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _dbcontext.Expenses
                .Skip((pagination.PageNumber - 1) * pagination.PageSize )
                .Take(pagination.PageSize)
                .ToListAsync();
            return pagedData;
        }
    }
}    