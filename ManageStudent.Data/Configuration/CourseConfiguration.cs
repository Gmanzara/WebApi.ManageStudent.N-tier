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
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.Score);
                
            builder
                .Property(m => m.CourseName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Courses");
        }
    }
}
