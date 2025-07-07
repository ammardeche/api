using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!; // Navigation property to Product
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}