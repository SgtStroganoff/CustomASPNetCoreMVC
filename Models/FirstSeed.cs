using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomASPNetCoreMVC.Areas.Identity.Data;

namespace CustomASPNetCoreMVC.Models
{
    public static class FirstSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            // Seed Roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Moderator", NormalizedName = "MODERATOR" },
                new IdentityRole { Name = "Basic", NormalizedName = "BASIC" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Users
            var passwordHasher = new PasswordHasher<AppUser>();

            List<AppUser> users = new List<AppUser>()
            {
                 // imporant: don't forget NormalizedUserName, NormalizedEmail 
                 new AppUser {
                    UserName = "superadmin",
                    FirstName = "Super",
                    LastName = "Admin",
                    PhoneNumber = "081288413881",
                    UsernameChangeLimit = 0,
                    NormalizedUserName = "SUPERADMIN",
                    Email = "superadmin@nxct.com",
                    NormalizedEmail = "SUPERADMIN@NXCT.COM",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                },
            };
            builder.Entity<AppUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            // Add Password For All Users
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "p@ssw0rd");

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "SuperAdmin").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Moderator").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Basic").Id
            });

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
