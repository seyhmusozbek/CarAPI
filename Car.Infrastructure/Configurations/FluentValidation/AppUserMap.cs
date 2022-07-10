using Car.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Configurations.FluentValidation
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(100);
            builder.Property(c => c.LastName).HasMaxLength(100);
            var user = new AppUser
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                Email = "test-user@test.com",
                NormalizedEmail = "TEST-USER@TEST.COM",
                FirstName = "Test",
                LastName = "User",
                UserName = "test-user",
                NormalizedUserName = "TEST-USER",
                PhoneNumber = "123456789",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var password = new PasswordHasher<AppUser>();
            var hashed = password.HashPassword(user, "test1234");
            user.PasswordHash = hashed;
            builder.HasData(
                user
                );
        }
    }
}
