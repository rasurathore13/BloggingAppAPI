using BloggingAppAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingAppAPI.UIModel
{
    public class BlogInfo
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string BlogMainImageUrl { get; set; }

        [Required]
        [MaxLength(150)]
        public string BlogHeading { get; set; }

        [Required]
        [MaxLength(250)]
        public string BlogBrief { get; set; }

        [Required]
        [MaxLength(50)]
        public string BlogAuthor { get; set; }

        public DateTime BlogDateTimeStamp { get; set; }

        public string BlogBody { get; set; }
    }
}
