using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;
using api.models;

namespace api.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepo;

        public ProductService(IProductRepository prod)
        {
            productRepo = prod;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product.Price < 0)
            {
                throw new Exception("the price of product he cant be less than 1 ");
            }
            var createdProduct = await productRepo.CreateProduct(product);
            return createdProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var isDelated = await productRepo.DeleteProductAsync(id);

            return isDelated;
        }

        public async Task<List<Product>> getAllProductAsync()
        {

            var products = await productRepo.getAllProductAsync();
            return products;
        }


        public async Task<Product?> getProductbyIdAsync(int id)
        {
            var product = await productRepo.getProductbyIdAsync(id);

            return product;
        }

        public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
        {
            var updatedProd = await productRepo.UpdateProductAsync(id, updatedProduct);

            return updatedProd;
        }
    }
}