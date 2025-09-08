using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required(ErrorMessage = "Category Name Is Required")]
        //[StringLength(100,MinimumLength = 3)]  // 3 : 100 Char
        [MaxLength(100),MinLength(3)]   // 3 : 100 Char
        
        public string Name { get; set; }

        // Relations
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
