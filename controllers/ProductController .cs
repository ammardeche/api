using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs.product;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllProducts()
        {
            var products = context.product.ToList().Select(
                p => p.ToProductDto()
            );
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var product = context.product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]

        public IActionResult CreateProduct([FromBody] CreateProductRequestDto request)
        {

            // return to us the created productD
            var ProductModel = request.CreateProductDto();
            context.product.Add(ProductModel);
            context.SaveChanges();
            // Return the created product with a 201 Created response
            // along with the location of the new resource
            // using CreatedAtAction to return the URI of the created resource
            return CreatedAtAction(nameof(GetProductById), new { id = ProductModel.Id }, ProductModel.ToProductDto());
        }

        [HttpPut("{id}")]

        public IActionResult updateProduct([FromRoute] int id, [FromBody] UpdateProductRequestDto request)
        {
            var currentProduct = context.product.FirstOrDefault(p => p.Id == id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            currentProduct.Name = request.Name;
            currentProduct.Description = request.Description;
            currentProduct.Price = request.Price;

            context.SaveChanges();
            return Ok(currentProduct.ToProductDto());
        }

        [HttpDelete("{id}")]

        public IActionResult removeProduct([FromRoute] int id)
        {
            var product = context.product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            context.product.Remove(product);
            return NoContent();
        }


    }
}