using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.Model
{
    public class Blog
    {
        [Key]
        int BlogId { get; set; }

        [Required]
        string BlogMainImageUrl { get; set; }

        [Required]
        [MaxLength(150)]
        string BlogHeading { get; set; }

        [Required]
        [MaxLength(250)]
        string BlogBrief { get; set; }

        [Required]
        [MaxLength(50)]
        string BlogAuthor { get; set; }
        
        DateTime BlogDateTimeStamp { get; set; }

    }
}
