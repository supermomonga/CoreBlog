using CoreBlog.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreBlog.Policies
{
    public class OwnerRequirement<TModel> : IAuthorizationRequirement
    {
        private Func<TModel, ApplicationUser, bool> _expr;
        public OwnerRequirement(Expression<Func<TModel, ApplicationUser, bool>> expr)
        {
            _expr = expr.Compile();
        }

        public bool IsOwner(TModel resource, ApplicationUser user)
        {
            return _expr.Invoke(resource, user);
        }
    }
}
