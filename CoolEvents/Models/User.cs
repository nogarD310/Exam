using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEvents.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Role { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public virtual HashSet<EventUser> EventUsers { get; set; }
        public User()
        {
            EventUsers = new HashSet<EventUser>();
        }
    }
}