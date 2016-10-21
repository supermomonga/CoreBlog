using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CoreBlog.Models;
using CoreBlog.Services;
using Microsoft.Extensions.Logging;
using CoreBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBlog.Controllers
{
    public class ApplicationController : Controller
    {
        internal readonly ApplicationDbContext _context;
        internal readonly UserManager<ApplicationUser> _userManager;
        internal readonly SignInManager<ApplicationUser> _signInManager;
        internal readonly IEmailSender _emailSender;
        internal readonly ISmsSender _smsSender;

        public ApplicationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        protected async Task<ApplicationUser> CurrentUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userWithProfile = await _context.Users.Include(u => u.Profile).SingleAsync(u => u.Id == user.Id);
            return userWithProfile;
        }

        protected async Task<UserProfile> CurrentUserProfile()
        {
            var user = await CurrentUser();
            return user.Profile;
        }
    }
}