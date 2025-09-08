using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //Relations
        // User Who Write The Comment
        public int UserId { get; set; }
        public User User { get; set; }
        // Post Belongs to
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
