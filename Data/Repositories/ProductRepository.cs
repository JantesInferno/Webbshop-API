using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_API_Topstyles.Data.Contexts;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly WebshopDbContext _context;

        public ProductRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Product product)
        {
            await _context.Products.AddAsync(product);

            return await Save();
        }

        public async Task<List<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.Where(predicate).ToListAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        
        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> Remove(Product product)
        {
            _context.Products.Remove(product);

            return await Save();
        }


        public async Task<bool> Update(Product product)
        {
            _context.Products.Update(product);

            return await Save();
        }

        private async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
