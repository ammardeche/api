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
                Content = ModelComment.Content,
                CreatedAt = ModelComment.CreatedAt,
                ProductId = ModelComment.ProductId,
            };

        }

    }
}