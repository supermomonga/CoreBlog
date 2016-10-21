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

        private DateTime _PostedAt;
        [Required]
        public DateTime PostedAt
        {
            get
            {
                if(_PostedAt.Equals(DateTime.MinValue))
                {
                    _PostedAt = DateTime.Now;
                }
                return _PostedAt;
            }
            set
            {
                _PostedAt = value;
            }
        }

        [Required]
        public UserProfile Author { get; set; }

        [Required]
        public bool IsPublished { get; set; }
    }
}
