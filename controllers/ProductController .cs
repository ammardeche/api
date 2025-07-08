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

        public IActionResult CreateProduct([FromBody] CreateProductRequestDto stockDto)
        {
            var stockModel = stockDto.toCreateProductDto();
            context.product.Add(stockModel);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = stockModel.Id }, stockModel.ToProductDto());
        }


    }
}