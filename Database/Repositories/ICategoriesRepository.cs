using TransactionAPI.Database.Entities;
using TransactionAPI.Models;

namespace TransactionAPI.Database.Repositories
{
     public interface ICategoriesRepository
    {
        Task<PagedSortedList<CategoryEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        
        Task<CategoryEntity> Create(CategoryEntity category);

        Task<CategoryEntity> Get(string code);

        Task<bool> Delete(string code);
    }
}