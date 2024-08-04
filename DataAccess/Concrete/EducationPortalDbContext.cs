using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EducationPortalDbContext : IdentityDbContext<User, Role, int>
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=EducationPortal;Trusted_Connection=true;TrustServerCertificate=true;integrated Security=true;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<InstructorType> InstructorTypes { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        //public DbSet<Role> Roles { get; set; }

    }
}
