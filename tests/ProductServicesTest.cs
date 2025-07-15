using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;
using api.models;
using api.services;
using Moq;
using Xunit;

namespace api.tests
{
    public class ProductServicesTest
    {
        //     private readonly Mock<IProductRepository> _mockRepo;
        //     private readonly ProductService _productService;

        //     public ProductServiceTests()
        //     {
        //         _mockRepo = new Mock<IProductRepository>();
        //         _productService = new ProductService(_mockRepo.Object);
        //     }

        //     [Fact]
        //     public async Task GetAllProductAsync_ReturnsListOfProducts()
        //     {
        //         // Arrange
        //         var mockProducts = new List<Product>
        //         {
        //             new Product { Id = 1, Name = "Laptop", Description = "Gaming", Price = 1200 },
        //             new Product { Id = 2, Name = "Mouse", Description = "Wireless", Price = 50 }
        //         };

        //         _mockRepo
        //             .Setup(repo => repo.getAllProductAsync())
        //             .ReturnsAsync(mockProducts);

        //         // Act
        //         var result = await _productService.getAllProductAsync();

        //         // Assert
        //         Assert.NotNull(result);
        //         Assert.IsType<List<Product>>(result);
        //         Assert.Equal(2, result.Count);
        //         Assert.Equal("Laptop", result[0].Name);
        //     }
        // }
    }
}
