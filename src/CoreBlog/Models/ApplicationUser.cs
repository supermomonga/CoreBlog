using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace CoreBlog.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        private UserProfile _Profile;
        public UserProfile Profile
        {
            get{
                return _Profile ?? (_Profile = new UserProfile());
            }
            set {
                _Profile = value;
            }
        }
    }
}