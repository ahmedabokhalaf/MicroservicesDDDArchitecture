using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Controllers.CategoriesController.Response;
using ProductMicroservice.Controllers.ProductsController.Request;
using ProductMicroservice.Controllers.ProductsController.Response;
using ProductMicroservice.Implementations;
using ProductMicroservice.Interfaces;
using ProductMicroservice.ProductAggregate.Input;
using ProductMicroservice.ProductAggregate;
using ProductMicroservice.Controllers.CategoriesController.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers.CategoriesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            if (!categories.Any()) return NotFound();
            return Ok(categories.Adapt<IEnumerable<CategoryResponse>>());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category.Adapt<CategoryResponse>());
        }

        // POST api/<CategoriesController>
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var categoryInput = request.Adapt<CategoryInput>();
                var category = categoryInput.Adapt<Category>();
                await _categoryRepository.CreateAsync(category);
                return Ok(category.Adapt<CategoryResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var category = await _categoryRepository.GetByIdAsync(request.Id);
                if (category == null) return NotFound();
                var categoryInput = request.Adapt<CategoryInput>();
                //await product.UpdateProduct(productInput);
                await _categoryRepository.CreateAsync(category);
                return Ok(category.Adapt<CategoryResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null) return NotFound();
                await _categoryRepository.DeleteAsync(category);
                return Ok(category.Adapt<CategoryResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
