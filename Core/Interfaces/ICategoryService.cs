using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
    }
}
