using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductByName(string searchTerm);
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);

    }
}
