using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Required]
        public DateTime PostedAt { get; set; }

        [Required]
        public UserProfile Author { get; set; }

        [Required]
        public bool IsPublished { get; set; }
    }
}
