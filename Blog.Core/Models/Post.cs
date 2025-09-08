using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        [Required,MaxLength(400)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relations 
        // User Who create Post
        // value Container
        public int UserId { get; set; }
        // define the ralation
        public User User { get; set; }
        // Category belongs to
        public int CategoryId  { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
