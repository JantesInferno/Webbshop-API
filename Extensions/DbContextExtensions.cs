using Microsoft.EntityFrameworkCore;
using Web_API_Topstyles.Data.Contexts;

namespace Web_API_Topstyles.Extensions
{
    public static class DbContextExtensions
    {
        public static void ConfigureDbContexts(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WebshopDbContext>(
                options => options.UseSqlServer(config["ConnectionString"])
                );


        }
    }
}
