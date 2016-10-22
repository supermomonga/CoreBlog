using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBlog.Data;
using CoreBlog.Models;
using CoreBlog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CoreBlog.Controllers
{
    public class HomeController : ApplicationController
    {
        protected readonly ILogger _logger;
        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            IAuthorizationService authorizationService,
            ApplicationDbContext context) : base(userManager, signInManager, emailSender, smsSender, authorizationService, context)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
