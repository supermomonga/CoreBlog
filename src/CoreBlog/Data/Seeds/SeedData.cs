using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Data.Seeds
{
    public class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var rm = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(! await rm.RoleExistsAsync("Administrator"))
                {
                    await rm.CreateAsync(new IdentityRole
                    {
                        Name = "Administrator"
                    });
                }
            }
        }
    }
}
