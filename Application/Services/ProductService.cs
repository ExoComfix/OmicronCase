using OmicronCase.Domain.Entities;
using OmicronCase.Infrastructure.Data;
using OmicronCase.Infrastructure.Errors;
using Microsoft.EntityFrameworkCore;

namespace OmicronCase.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly OmicronContext _context;

        public ProductService(OmicronContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new OmicronException(ErrorCode.ValidationError, "Product cannot be null.");
            }

            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new OmicronException(ErrorCode.DatabaseError, "Product not found.");
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new OmicronException(ErrorCode.DatabaseError, "Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
