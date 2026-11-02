
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Anton_Antipov_kt_31_23.Models;

namespace Anton_Antipov_kt_31_23.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

            builder.HasKey(x => x.StudentId);

            builder.Property(x => x.StudentId)
                .HasColumnName("student_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .HasColumnName("student_firstname")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasColumnName("student_lastname")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GroupId)
                .HasColumnName("group_id")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
