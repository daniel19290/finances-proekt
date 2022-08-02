using TransactionAPI.Commands;
using TransactionAPI.Models;

namespace TransactionAPI.Services
{
    public interface ICategoriesService
    {
        Task<PagedSortedList<Models.Category>> GetCategories(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        Task<Models.Category> GetCategory(string Code);
        Task<Models.Category> CreateCategory(CreateCategoryCommand command);
        Task<bool> DeleteCategory(string Code);
    }
}