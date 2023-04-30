using CoolEvents.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CoolEvents
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void SeedDefaultUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));

                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@example.com"
                };
                var passwordHasher = new PasswordHasher();
                user.PasswordHash = passwordHasher.HashPassword("Complex1234:C");
                userManager.Create(user);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole
                    {
                        Name = "Admin"
                    };
                    roleManager.Create(role);
                }
                userManager.AddToRole(user.Id, "Admin");
        }
    }
}