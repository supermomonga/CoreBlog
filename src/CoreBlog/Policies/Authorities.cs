using CoreBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Policies
{
    public class Authorities
    {
        public static OwnerRequirement<Article, ApplicationUser> Article =
            new OwnerRequirement<Article, ApplicationUser>((Article a, ApplicationUser u) => a.Author.User.Id == u.Id);

        public static OwnerRequirement<UserProfile, ApplicationUser> Profile =
            new OwnerRequirement<UserProfile, ApplicationUser>((UserProfile p, ApplicationUser u) => p.User.Id == u.Id);

        public static OwnerRequirement<ApplicationUser, ApplicationUser> User =
            new OwnerRequirement<ApplicationUser, ApplicationUser>((ApplicationUser one, ApplicationUser another) => one.Id == another.Id);
    }
}
