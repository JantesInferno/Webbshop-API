using Microsoft.AspNetCore.Mvc;
using Web_API_Topstyles.Core.Interfaces;

namespace Web_API_Topstyles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("/api/category/get-all-categories")]
        [HttpGet]
        public async Task<IResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            return Results.Ok(categories);
        }

        [Route("/api/category/get-category-by-id/{categoryId}")]
        [HttpGet]
        public async Task<IResult> GetCategoryById(int categoryId)
        {
            if (categoryId <= 0)
                return Results.Problem($"Felaktigt värde för kategoriid {categoryId}", statusCode: 400);

            var categories = await _categoryService.GetCategoryById(categoryId);

            return Results.Ok(categories);
        }
    }
}
