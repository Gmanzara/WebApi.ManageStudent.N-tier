using ManageStudent.Core.Models;
using ManageStudent.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ManageStudent.Data
{
    public class ManageStudentDbContext : DbContext
    {
        public DbSet<Student> students {  get; set; }
        public DbSet<Course> courses { get; set;}
        public DbSet<User> Users { get; set; }
        public ManageStudentDbContext( DbContextOptions<ManageStudentDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new StudentConfiguration() );
               
            builder
                .ApplyConfiguration(new CourseConfiguration() );

            builder
                .ApplyConfiguration(new UserConfiguration() );
        }
    }
}
