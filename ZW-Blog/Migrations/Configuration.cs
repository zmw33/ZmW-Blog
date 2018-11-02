using System.Data.Entity.Migrations;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using ZW_Blog.Models;
using Microsoft.AspNet.Identity;

namespace ZW_Blog.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ZW_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ZW-Blog.Models.ApplicationDbContext";
        }

        protected override void Seed(ZW_Blog.Models.ApplicationDbContext context)
        {
            //create a few roles (Admin, Moderator)
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r=> r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(m => m.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            //create a few users (i.e. me and instructor)
            var userManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            //assign users to roles (me and instructor)
            // "u => u.email" means that u "goes to u.email"
            //use example email
            if (!context.Users.Any(u => u.Email == "zacharywilsonm@gmail.com"))
            {
                //any user will be identified by ApplicationUser
                userManager.Create(new ApplicationUser
                {
                    UserName = "zacharywilsonm@gmail.com",
                    Email = "zacharywilsonm@gmail.com",
                    FirstName = "Zachary",
                    LastName = "Wilson",
                    DisplayName = "ZmWAdmin"
                }, "Pigbull2017!");
            }

            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@coderfoundry.com",
                    Email = "moderator@coderfoundry.com",
                    FirstName = "Coder",
                    LastName = "Foundry",
                    DisplayName = "CoFoModerator"
                }, "password1");
            }

            //assign role to user
            var adminId = userManager.FindByEmail("zacharywilsonm@gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var moderatorId = userManager.FindByEmail("moderator@coderfoundry.com").Id;
            userManager.AddToRole(moderatorId, "Moderator");
        }
    }
}
