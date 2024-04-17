using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using Web_API_Topstyles.Data.Contexts;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Topstyles.Domain.Identity;
/*
namespace Web_API_Topstyles.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        // LEGACY CODE

        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(User user)
        {
            await _context.Users.AddAsync(user);

            return await Save();
        }

        public async Task<List<User>> Find(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> Remove(User user)
        {
            _context.Users.Remove(user);

            return await Save();
        }


        public async Task<bool> Update(User user)
        {
            _context.Users.Update(user);

            return await Save();
        }

        private async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
*/