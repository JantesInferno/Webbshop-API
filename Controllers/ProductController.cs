using Microsoft.AspNetCore.Mvc;
using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("/api/product/get-all-products")]
        [HttpGet]
        public async Task<IResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Results.Ok(products);
        }

        [Route("/api/product/get-products-by-name/{searchTerm}")]
        [HttpGet]
        public async Task<IResult> GetProductByName(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return Results.Problem("Sökning kan inte göras utan en sökterm", statusCode: 400);

            var products = await _productService.GetProductByName(searchTerm);

            return Results.Ok(products);
        }

        [Route("/api/product/get-products-by-id/{productId}")]
        [HttpGet]
        public async Task<IResult> GetProductById(int productId)
        {
            if (productId <= 0)
                return Results.Problem($"Felaktigt värde för produktid {productId}", statusCode: 400);

            var result = await _productService.GetProductById(productId);

            return Results.Ok(result);
        }
    }
}
