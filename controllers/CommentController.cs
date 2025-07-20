using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs.comment;
using api.Interface;
using api.Mapper;
using api.models;
using api.services;
using Dumpify;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;
        private readonly IProductRepository _productRepository;
        public CommentController(ICommentRepository commentRepository, IProductRepository productService)
        {
            _commentRepository = commentRepository;
            _productRepository = productService;
        }

        [HttpGet]

        public async Task<IActionResult> getAllAsync()

        {
            var comments = await _commentRepository.GetAllCommentAsync();

            var commentDto = comments.Select(p => p.ToCommentDto()).ToList();


            if (commentDto == null)
            {
                return NotFound();
            }

            return Ok(commentDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> getByIdAsync([FromRoute] int id)

        {
            var comment = await _commentRepository.getByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{productId}")]

        public async Task<IActionResult> createAsync([FromRoute] int productId, CreateCommentDto commentDto)
        {
            if (!await _productRepository.ProductExistAsync(productId))
            {
                return BadRequest("product does not exist");
            }
            // ..
            var commentModel = commentDto.ToCreateDto(productId);
            Console.WriteLine("comment id : ", commentModel.Id);
            await _commentRepository.CreateAsync(commentModel);

            commentModel.Dump();
            return Ok(commentModel.ToCommentDto());


        }


    }


}