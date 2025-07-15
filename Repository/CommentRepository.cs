using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.Interface;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllCommentAsync()
        {
            return await _context.comments.ToListAsync();


        }

        public async Task<Comment?> getByIdAsync(int id)
        {
            return await _context.comments.FindAsync(id);
        }


    }
}