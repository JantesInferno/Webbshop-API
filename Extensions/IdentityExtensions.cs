using Microsoft.AspNetCore.Identity;
using Web_API_Topstyles.Data.Contexts;
using Web_API_Topstyles.Domain.Identity;

namespace Web_API_Topstyles.Extensions
{
    public static class IdentityExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<WebshopDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
