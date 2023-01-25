using AutoMapper;
using ExpenseTracker.Core.Contracts;
using ExpenseTracker.Core.Models;
using ExpneseTracker.Core.ViewModels;

namespace ExpenseTracker.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly IMapper _mapper;
        public CategoryRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
        }

        public Task<CategoryViewModel> InsertAsync(CategoryViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<CategoryViewModel>> ICategoryRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<CategoryViewModel?> ICategoryRepository.GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        Task<CategoryViewModel> ICategoryRepository.RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        Task<CategoryViewModel> ICategoryRepository.UpdateAsync(Category model)
        {
            throw new NotImplementedException();
        }
    }
}