using CoreBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Policies
{
    public class Authorities
    {
        public static OwnerRequirement<Article> Article =
            new OwnerRequirement<Article>((Article a, ApplicationUser u) => a.Author.User.Id == u.Id);

        public static OwnerRequirement<UserProfile> Profile =
            new OwnerRequirement<UserProfile>((UserProfile p, ApplicationUser u) => p.User.Id == u.Id);

        public static OwnerRequirement<ApplicationUser> User =
            new OwnerRequirement<ApplicationUser>((ApplicationUser one, ApplicationUser another) => one.Id == another.Id);
    }
}
