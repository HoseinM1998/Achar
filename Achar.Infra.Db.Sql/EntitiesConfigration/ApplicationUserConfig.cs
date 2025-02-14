using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achar.Infra.Db.SqLServer.EntitiesConfigration
{
    public class ApplicationUserConfig
    {
        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
        {
            new ApplicationUser()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09913466961",
                FirstName = "ادمین",
                LastName = "ادمین",
                IsDelete = false,
                ProfileImageUrl = "/userassets/img/1.png",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser()
            {
                Id = 2,
                UserName = "Hosein@gmail.com",
                NormalizedUserName = "HOSEIN@GMAIL.COM",
                Email = "Hosein@gmail.com",
                NormalizedEmail = "HOSEIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09913466961",
                FirstName = "حسین",
                LastName = "مصلحی",
                IsDelete = false,
                ProfileImageUrl = "/userassets/img/1.png",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser()
            {
                Id = 3,
                UserName = "Javad@gmail.com",
                NormalizedUserName = "JAVAD@GMAIL.COM",
                Email = "Javad@gmail.com",
                NormalizedEmail = "JAVAD@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09913466961",
                FirstName = "جواد",
                LastName = "مرادی",
                IsDelete = false,
                ProfileImageUrl = "/userassets/img/1.png",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser()
            {
                Id = 4,
                UserName = "Aref@gmail.com",
                NormalizedUserName = "AREF@GMAIL.COM",
                Email = "Aref@gmail.com",
                NormalizedEmail = "AREF@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09913466961",
                FirstName = "عارف",
                LastName = "بهمنی",
                IsDelete = false,
                ProfileImageUrl = "/userassets/img/1.png",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser()
            {
                Id = 5,
                UserName = "Saeid@gmail.com",
                NormalizedUserName = "SAEID@GMAIL.COM",
                Email = "Saeid@gmail.com",
                NormalizedEmail = "SAEID@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09913466961",
                FirstName = "سعید",
                LastName = "لک‌",
                IsDelete = false,
                ProfileImageUrl = "/userassets/img/1.png",
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser()
            {
                Id = 6,
                UserName = "Sahar@gmail.com",
                NormalizedUserName = "SAHAR@GMAIL.COM",
                Email = "Sahar@gmail.com",
                NormalizedEmail = "SAHAR@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09913466961",
                FirstName = "سحر",
                IsDelete = false,
                ProfileImageUrl = "/userassets/img/1.png",
                SecurityStamp = Guid.NewGuid().ToString()
            },
        };
            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "123456");

                builder.Entity<ApplicationUser>().HasData(user);
            }
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Expert", NormalizedName = "EXPERT" },
                new IdentityRole<int>() { Id = 3, Name = "Customer", NormalizedName = "CUSTOMER" }
            );
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 3 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 4 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 5 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 6 }
            );
        }
    }
}
