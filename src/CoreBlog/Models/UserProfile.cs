using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Models
{
    public class UserProfile
    {
        [Required]
        public int Id { get; set; }

        public string ScreenName { get; set; }

        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<Article> Articles { get; set; }
    }
}
