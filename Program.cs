using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Core.Services;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Data.Repositories;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Topstyles.Extensions;
using Web_API_Webshop.Extensions;

namespace Web_API_Topstyles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddAzureKeyVault(new Uri(builder.Configuration["VaultURI"]),
                new DefaultAzureCredential());

            builder.Services.AddControllers();

            builder.Services.ConfigureCors();

            builder.Services.ConfigureIdentity();

            builder.Services.ConfigureCookie();

            builder.Services.ConfigureDbContexts(builder.Configuration);

            builder.Services.AddSwaggerExtended();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IRepository<Order>, OrderRepository>();


            var app = builder.Build();

            app.UseRouting();

            app.UseCors();

            app.UseSwaggerExtended();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}
