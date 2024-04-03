using Microsoft.AspNetCore.Mvc;
using OmicronCase.Application.Services;
using OmicronCase.Domain.Entities;
using OmicronCase.Domain.Models;
namespace OmicronCase.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Product>>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(new BaseResponse<IEnumerable<Product>>(true, "Products retrieved successfully", products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Product>>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new BaseResponse<Product>(false, "Product not found"));
            }
            return Ok(new BaseResponse<Product>(true, "Product retrieved successfully", product));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Product>>> PostProduct(ProductCreateModel productCreateModel)
        {
            try
            {
                Product newProduct = new Product();
                newProduct.Title = productCreateModel.Title;
                newProduct.Description = productCreateModel.Description;
                newProduct.Category = productCreateModel.Category;
                newProduct.StockQuantity = productCreateModel.StockQuantity;
                newProduct.LimitStock = productCreateModel.LimitStock;
                newProduct.IsActive = productCreateModel.IsActive;
                newProduct.SetIsActive();
                newProduct = await _productService.CreateProductAsync(newProduct);
                return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, new BaseResponse<Product>(true, "Product created successfully", newProduct));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<Product>(false, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Product product)
        {
            try
            {
                await _productService.UpdateProductAsync(product);
                product.SetIsActive();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<Product>(false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<Product>(false, ex.Message));
            }
        }
    }
}
