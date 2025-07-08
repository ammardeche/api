using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.product;
using api.models;

namespace api.Mapper
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public static Product toCreateProductDto(this CreateProductRequestDto StockDto)
        {
            return new Product
            {
                Name = StockDto.Name,
                Description = StockDto.Description,
                Price = StockDto.Price
            };
        }
    }
}