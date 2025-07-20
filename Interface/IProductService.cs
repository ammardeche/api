using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interface
{
    public interface IProductService
    {

        Task<List<Product>> getAllProductAsync();
        Task<Product?> getProductbyIdAsync(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product?> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);

        Task<bool> productExistAsync(int id);


    }
}