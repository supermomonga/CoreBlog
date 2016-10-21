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
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly IEmailSender _emailSender;
        protected readonly ISmsSender _smsSender;

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
            var userWithProfile = _context.Users.Where(u => u.Id == user.Id).Include(u => u.Profile).Single();
            return userWithProfile;
        }

        protected async Task<UserProfile> CurrentUserProfile()
        {
            var user = await CurrentUser();
            return user.Profile;
        }
    }
}