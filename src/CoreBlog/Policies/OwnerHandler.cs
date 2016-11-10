using CoreBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Policies
{
    public class OwnerHandler<TModel, TUser> : AuthorizationHandler<OwnerRequirement<TModel, TUser>, TModel> where TUser : IdentityUser
    {
        internal readonly UserManager<TUser> _userManager;
        public OwnerHandler(UserManager<TUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OwnerRequirement<TModel, TUser> requirement,
            TModel resource)
        {
            var user = _userManager.GetUserAsync(context.User).GetAwaiter().GetResult();
            if(requirement.IsOwner(resource, user))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
