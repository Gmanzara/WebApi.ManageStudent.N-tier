using ManageStudent.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageStudent.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
               .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .UseIdentityColumn();

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);            

            builder
                .ToTable("Students");
        }
    }
}
