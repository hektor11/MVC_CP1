using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Checkpoint1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Checkpoint1.Models.ApplicationUser> ApplicationUsers { get; set; }
        //Add other model db context
        public System.Data.Entity.DbSet<Checkpoint1.Models.Data.Admin> Admins { get; set; }
        public System.Data.Entity.DbSet<Checkpoint1.Models.Data.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<Checkpoint1.Models.Data.Question> Questions { get; set; }
        public System.Data.Entity.DbSet<Checkpoint1.Models.Data.Response> Responses { get; set; }
        public System.Data.Entity.DbSet<Checkpoint1.Models.Data.Survey> Survey { get; set; }
    }
}