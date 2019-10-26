using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.Model
{
    public class BlogBody
    {
        [Key]
        public int BlogBodyId { get; set; }
        
        [Required]
        public int BlogId { get; set; }

        [Required]
        public string EntireBlog { get; set; }
    }
}
