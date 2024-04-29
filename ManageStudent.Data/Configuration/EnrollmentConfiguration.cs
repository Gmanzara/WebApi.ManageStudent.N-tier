using ManageStudent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStudent.Data.Configuration
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(s => s.Id)
                .UseIdentityColumn();
            builder
                .Property(s => s.Score)
                .IsRequired();


            builder
                .HasOne(s => s.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(s => s.StudentId);
            
            builder
                .HasOne(c => c.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(c => c.CourseId);
            builder
                .ToTable("Enrollments");
        }
    }
}
