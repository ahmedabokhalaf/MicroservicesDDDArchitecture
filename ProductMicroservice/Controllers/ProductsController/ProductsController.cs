using Azure.Core;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Controllers.ProductsController.Request;
using ProductMicroservice.Controllers.ProductsController.Response;
using ProductMicroservice.Interfaces;
using ProductMicroservice.ProductAggregate;
using ProductMicroservice.ProductAggregate.Input;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers.ProductsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            if (!products.Any()) return NotFound();
            return Ok(products.Adapt<IEnumerable<ProductResponse>>());
        }

        // GET api/<ProductsController>/5
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product.Adapt<ProductResponse>());
        }

        // POST api/<ProductsController>
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest();
                var productInput = request.Adapt<ProductInput>();
                var product = productInput.Adapt<Product>();
                await _productRepository.CreateAsync(product);
                return Ok(product.Adapt<ProductResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var product = await _productRepository.GetByIdAsync(request.Id);
                if (product == null) return NotFound();
                var productInput = request.Adapt<ProductInput>();
                //await product.UpdateProduct(productInput);
                await _productRepository.CreateAsync(product);
                return Ok(product.Adapt<ProductResponse>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null) return NotFound();
                await _productRepository.DeleteAsync(product);
                return Ok(product.Adapt<ProductResponse>());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
