using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs.product;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDBContext context;
        public ProductController(ApplicationDBContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await context.product.ToListAsync();
            var productdto = context.product.Select(p => p.ToProductDto());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await context.product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto request)
        {

            // return to us the created productD
            var ProductModel = request.CreateProductDto();
            await context.product.AddAsync(ProductModel);
            await context.SaveChangesAsync();
            // Return the created product with a 201 Created response
            // along with the location of the new resource
            // using CreatedAtAction to return the URI of the created resource
            return CreatedAtAction(nameof(GetProductById), new { id = ProductModel.Id }, ProductModel.ToProductDto());
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> updateProduct([FromRoute] int id, [FromBody] UpdateProductRequestDto request)
        {
            var currentProduct = await context.product.FirstOrDefaultAsync(p => p.Id == id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            currentProduct.Name = request.Name;
            currentProduct.Description = request.Description;
            currentProduct.Price = request.Price;

            await context.SaveChangesAsync();
            return Ok(currentProduct.ToProductDto());
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> removeProduct([FromRoute] int id)
        {
            var product = await context.product.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            context.product.Remove(product);
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}