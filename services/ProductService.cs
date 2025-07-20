using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;
using api.models;
using api.Repository;

namespace api.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product.Price < 0)
            {
                throw new Exception("the price of product he cant be less than 1 ");
            }
            var createdProduct = await _productRepository.CreateProduct(product);
            return createdProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var isDelated = await _productRepository.DeleteProductAsync(id);

            return isDelated;
        }

        public async Task<List<Product>> getAllProductAsync()
        {

            var products = await _productRepository.getAllProductAsync();
            return products;
        }


        public async Task<Product?> getProductbyIdAsync(int id)
        {
            var product = await _productRepository.getProductbyIdAsync(id);

            return product;
        }

        public Task<bool> productExistAsync(int id)
        {
            return _productRepository.ProductExistAsync(id);
        }

        public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
        {
            var updatedProd = await _productRepository.UpdateProductAsync(id, updatedProduct);
            return updatedProd;
        }



    }
}