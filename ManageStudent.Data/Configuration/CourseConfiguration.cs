using ManageStudent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStudent.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(c => c.Id)
                .UseIdentityColumn();
                
            builder
                .Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Courses");
        }
    }  
}
