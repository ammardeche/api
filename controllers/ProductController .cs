using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs.product;
using api.Interface;
using api.Mapper;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDBContext context;
        private readonly IProductRepository productRepo;
        public ProductController(ApplicationDBContext context, IProductRepository prodRepo)
        {
            this.productRepo = prodRepo;
            this.context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepo.getAllProductAsync();
            var prodDto = products.Select(p => p.ToProductDto()).ToList();

            if (prodDto == null)
            {
                return NotFound();
            }

            return Ok(prodDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await productRepo.getProductbyIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductDto());

        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            var createdProduct = await productRepo.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct.ToProductDto());

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> updateProduct([FromRoute] int id, [FromBody] UpdateProductRequestDto request)
        {
            var updatedData = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };

            var updatedProduct = await productRepo.UpdateProductAsync(id, updatedData);

            return Ok(updatedProduct.ToProductDto());
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> removeProduct([FromRoute] int id)
        {
            var isDelated = await productRepo.DeleteProductAsync(id);

            if (!isDelated)
            {
                return NotFound();
            }

            return NoContent();


        }


    }
}