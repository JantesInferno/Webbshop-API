using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Topstyles.Domain.Identity;

namespace Web_API_Topstyles.Data.Contexts
{
    public class WebshopDbContext : IdentityDbContext<User>
    {
        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
    }
}
