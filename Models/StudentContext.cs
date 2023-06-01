using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Configuration;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Models
{
    public class StudentContext :IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) {
        
        
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


             modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
        }
    }
}
