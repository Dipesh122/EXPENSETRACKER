using AutoMapper;
using ExpenseTracker.Core.Contracts;
using ExpenseTracker.Core.pagination;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;
        protected BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> GetAllAsync(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = _dbSet.Skip((validFilter.PageNumber -1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            return await pagedData;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("cannot be null");
        }
        public IQueryable<TEntity> GetQueryableLinq()
        {
            return _dbSet;
        }

        public async Task<TEntity> RemoveAsync(int id)
        {
            var result = await _dbSet.FindAsync(id) ?? throw new Exception("cannot remove non-existent entity");
            _dbSet.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var data = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}