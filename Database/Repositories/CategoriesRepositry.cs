using Microsoft.EntityFrameworkCore;
using TransactionAPI.Database.Entities;
using TransactionAPI.Models;


namespace TransactionAPI.Database.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
       private readonly CategoriesDbContext _dbContext;

        public CategoriesRepository(CategoriesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryEntity> Create(CategoryEntity category)
        {
            _dbContext.Categories.Add(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<bool> Delete(string code)
        {
            var category = await Get(code);

            if (category == null)
            {
                return false;
            }

            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryEntity> Get(string code)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(p => p.Ccode == code);
        }

        public async Task<PagedSortedList<CategoryEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var query = _dbContext.Categories.AsQueryable();

            var totalCount = query.Count();

            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "code":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Ccode) : query.OrderByDescending(x => x.Ccode);
                        break;
                    case "parentCode":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.parentCode) : query.OrderByDescending(x => x.parentCode);
                        break;
                    default:
                    case "name":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
                        break;
                }
            } 
            else
            {
                query = query.OrderBy(p => p.Name);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new PagedSortedList<CategoryEntity>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }
    }
}
