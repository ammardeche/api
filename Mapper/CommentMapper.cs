using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.comment;
using api.models;

namespace api.Mapper
{
    public static class CommentMapper
    {

        public static CommentDto ToCommentDto(this Comment ModelComment)
        {
            return new CommentDto
            {
                Id = ModelComment.Id,
                Title = ModelComment.Title,
                Content = ModelComment.Content,
                CreatedAt = ModelComment.CreatedAt,
                ProductId = ModelComment.ProductId
            };
        }

        public static Comment ToCreateDto(this CreateCommentDto commentModel, int ProductId)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content,
                ProductId = ProductId,
            };
        }



    }
}