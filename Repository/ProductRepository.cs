using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.Interface;
using api.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.product.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.product.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return false;
            }
            _context.product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> ExistProduct(int id)
        {
            return _context.product.AnyAsync(p => p.Id == id);
        }

        public async Task<List<Product>> getAllProductAsync()
        {
            return await _context.product.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Product?> getProductbyIdAsync(int id)
        {
            var product = await _context.product.Include(c => c.Comments).FirstOrDefaultAsync(p => p.Id == id);
            return product;

        }

        public Task<bool> ProductExistAsync(int id)
        {
            return _context.product.AnyAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
        {
            var existingProduct = await _context.product.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();

            return existingProduct;


        }
    }
}