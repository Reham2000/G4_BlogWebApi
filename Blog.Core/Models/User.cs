using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50),MinLength(3)]
        public string UserName { get; set; }
        [Required]
        //[ RegularExpression("/^[^ ]+@/")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50), MinLength(4)]
        public string Password { get; set; } 
        

        // Relations

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
