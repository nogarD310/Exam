using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace CoolEvents.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventUser> EventUsers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventUser>()
                .HasKey(ea => new { ea.EventId, ea.UserId });

            modelBuilder.Entity<EventUser>()
                .HasRequired(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId);

            modelBuilder.Entity<EventUser>()
                .HasRequired(eu => eu.User)
                .WithMany(u => u.EventUsers)
                .HasForeignKey(eu => eu.UserId);

            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
        }
    }
}
