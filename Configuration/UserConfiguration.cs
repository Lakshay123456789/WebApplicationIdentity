using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = "634a60ec-96bc-4f37-937f-27ba52f58d41",
                    UserName = "admin123@gmail.com",
                    NormalizedUserName = "admin123@gmail.com",
                    Email = "admin123@gmail.com",
                    NormalizedEmail = "admin123@gmail.com",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin@123")
                },
                 new ApplicationUser
                 {
                     Id = "c80d49e8-a97c-45e6-babf-0760a6b86814",
                     UserName = "user123@gmail.com",
                     NormalizedUserName = "user123@gmail.com",
                     Email = "user123@gmail.com",
                     NormalizedEmail = "user123@gmail.com",
                     PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "user@123")
                 }
                );
        }
    }
}

