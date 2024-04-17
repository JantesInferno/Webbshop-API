using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_API_Topstyles.Data.Contexts;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly WebshopDbContext _context;

        public OrderRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Order order)
        {
            await _context.Orders.AddAsync(order);

            return await Save();
        }

        public async Task<List<Order>> Find(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.Where(predicate).ToListAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<bool> Remove(Order order)
        {
            _context.Orders.Remove(order);

            return await Save();
        }


        public async Task<bool> Update(Order order)
        {
            _context.Orders.Update(order);

            return await Save();
        }

        private async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
