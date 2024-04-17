using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_API_Topstyles.Data.Contexts;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly WebshopDbContext _context;

        public CategoryRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Category category)
        {
            await _context.Categories.AddAsync(category);

            return await Save();
        }

        public async Task<List<Category>> Find(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Categories.Where(predicate).ToListAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.Include(category => category.Products).ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.Include(i => i.Products)
                .FirstOrDefaultAsync(category => category.CategoryId == id);
        }

        public async Task<bool> Remove(Category category)
        {
            _context.Categories.Remove(category);

            return await Save();
        }


        public async Task<bool> Update(Category category)
        {
            _context.Categories.Update(category);

            return await Save();
        }

        private async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
