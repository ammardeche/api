using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.models;
using Microsoft.IdentityModel.Tokens;

namespace api.Interface
{
    public interface IProductRepository
    {
        // create CRUD operations (create , read , update , delete )
        Task<List<Product>> getAllProductAsync();
        Task<Product?> getProductbyIdAsync(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product?> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);

        Task<bool> ProductExistAsync(int id);

    }
}