using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductService(IRepository<Product> repo)
        {
            _productRepo = repo;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepo.GetAll();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepo.GetById(id);
        }

        public async Task<List<Product>> GetProductByName(string searchTerm)
        {
            return await _productRepo.Find(product => product.Title.ToLower().Contains(searchTerm.ToLower()));
        }
    }
}
