using AutoMapper;
using TransactionAPI.Commands;
using TransactionAPI.Database.Entities;
using TransactionAPI.Database.Repositories;
using TransactionAPI.Models;

namespace TransactionAPI.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }
        public async Task<Models.Category> CreateCategory(CreateCategoryCommand command)
        {
            var entity = _mapper.Map<CategoryEntity>(command);

            var existingCategory = await _categoriesRepository.Get(command.Code);
            if (existingCategory != null)
            {
                return null;
            }
            var result = _categoriesRepository.Create(entity);

            return _mapper.Map<Models.Category>(result);
        }

        public async Task<bool> DeleteCategory(string Code)
        {
            return await _categoriesRepository.Delete(Code);
        }

        public async Task<Models.Category> GetCategory(string Code)
        {
            var categoryEntity = await _categoriesRepository.Get(Code);

            if (categoryEntity == null)
            {
                return null;
            }

            return _mapper.Map<Models.Category>(categoryEntity);
        }

         public async Task<PagedSortedList<Models.Category>> GetCategories(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var result = await _categoriesRepository.List(page, pageSize, sortBy, sortOrder);

            return _mapper.Map<PagedSortedList<Models.Category>>(result);
        }
    }
    
}