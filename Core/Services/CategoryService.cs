using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepo.GetAll();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepo.GetById(id);
        }
    }
}
