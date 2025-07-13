using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.DTOs.comment;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
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


    }
}