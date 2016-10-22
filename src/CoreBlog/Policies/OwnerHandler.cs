using CoreBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Policies
{
    public class OwnerHandler<TModel> : AuthorizationHandler<OwnerRequirement<TModel>, TModel>
    {
        internal readonly UserManager<ApplicationUser> _userManager;
        public OwnerHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OwnerRequirement<TModel> requirement,
            TModel resource)
        {
            var user = _userManager.GetUserAsync(context.User).GetAwaiter().GetResult();
            var res = requirement.IsOwner(resource, user);
            if(res)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
