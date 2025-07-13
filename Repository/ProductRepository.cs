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
        private readonly ApplicationDBContext context;

        public ProductRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await context.product.AddAsync(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await context.product.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return false;
            }
            context.product.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> getAllProductAsync()
        {
            return await context.product.ToListAsync();
        }

        public async Task<Product?> getProductbyIdAsync(int id)
        {
            var product = await context.product.FindAsync(id);
            return product;

        }

        public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
        {
            var existingProduct = await context.product.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;

            await context.SaveChangesAsync();

            return existingProduct;


        }
    }
}