namespace Camones.Shop.Identity.Infrastructure
{
    using Camones.Shop.Identity.Domain;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        public void Seed(ApplicationDbContext context)
        {
            foreach (var rol in this.GetRoles())
                if (!context.Roles.Any(x => x.Name == rol.Name))
                    context.Roles.Add(rol);

            foreach (var user in this.GetUsers())
                if (!context.Users.Any(x => x.Id == user.Id))
                    context.Users.Add(user);

            foreach (var userRole in this.GetUserRoles())
                if (!context.UserRoles.Any(x => x.UserId == userRole.UserId && x.RoleId == userRole.RoleId))
                    context.UserRoles.Add(userRole);

            context.SaveChanges();
        }

        private IEnumerable<ApplicationRole> GetRoles()
        {
            return new ApplicationRole[]
            {
                new ApplicationRole
                {
                    Id = Guid.Parse("554ca91f-918d-456b-bded-745afb777e88"),
                    Name="Admin",
                    NormalizedName="Admin"
                }
            };
        }

        private IEnumerable<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Email = "afernandeznet@gmail.com",
                Id = Guid.Parse("fd8a6ad8-7555-422d-a1b3-1dc0371b0030"),
                UserName = "afernandeznet@gmail.com",
                NormalizedEmail = "AFERNANDEZNET@GMAIL.COM",
                NormalizedUserName = "AFERNANDEZNET@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "Camones2020.");
            users.Add(user);

            return users;
        }

        private IEnumerable<IdentityUserRole<Guid>> GetUserRoles()
        {
            var users = this.GetUsers();
            var adminRole = this.GetRoles().FirstOrDefault();

            List<IdentityUserRole<Guid>> administrators = new List<IdentityUserRole<Guid>>();

            foreach (var user in users)
            {
                administrators.Add(new IdentityUserRole<Guid>
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id
                });
            }

            return administrators;
        }
    }
}