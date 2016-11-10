using CoreBlog.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreBlog.Policies
{
    public class OwnerRequirement<TModel, TUser> : IAuthorizationRequirement
    {
        private Func<TModel, TUser, bool> _expr;
        public OwnerRequirement(Expression<Func<TModel, TUser, bool>> expr)
        {
            _expr = expr.Compile();
        }

        public bool IsOwner(TModel resource, TUser user)
        {
            return _expr.Invoke(resource, user);
        }
    }
}
