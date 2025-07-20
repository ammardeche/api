using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Interface
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentAsync();
        Task<Comment?> getByIdAsync(int id);

        Task<Comment> CreateAsync(Comment comment);

    }
}