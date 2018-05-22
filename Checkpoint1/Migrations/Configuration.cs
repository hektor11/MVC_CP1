namespace Checkpoint1.Migrations
{
    using Checkpoint1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Checkpoint1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Checkpoint1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //Add a user to the db
            context.Users.AddOrUpdate(
                u => u.UserName,
                new Models.ApplicationUser {
                        UserName = "hectuanerz@gmail.com",
                        Email = "hectuanerz@gmail.com",
                        FirstName = "Hector",
                        LastName = "Garcia",
                }
                );

            context.SaveChanges();
            // Create a UserManager to add a password to the previously created user
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            UserManager.AddPassword(context.Users.Where(u => u.UserName == "hectuanerz@gmail.com").FirstOrDefault().Id.ToString(),"123456");
            

            // Create RoleManager to create role for 'Admin'
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            RoleManager.Create(new IdentityRole {
                Name = "Admin"
            });
            RoleManager.Create(new IdentityRole
            {
                Name = "Customer"
            });

            context.SaveChanges();

            // Add user to 'Admin' Role
            UserManager.AddToRole(context.Users.Where(u => u.UserName == "hectuanerz@gmail.com").FirstOrDefault().Id.ToString(), "Admin");
            context.SaveChanges();

        }
    }
}
