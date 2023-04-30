namespace CoolEvents.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CoolEvents.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoolEvents.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                roleManager.Create(role);
            }
        }
    }
}
