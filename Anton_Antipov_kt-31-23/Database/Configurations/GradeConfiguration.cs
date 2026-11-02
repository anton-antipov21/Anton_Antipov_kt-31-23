
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Anton_Antipov_kt_31_23.Models;

namespace Anton_Antipov_kt_31_23.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("grades");

            builder.HasKey(x => x.GradeId);

            builder.Property(x => x.GradeId)
                .HasColumnName("grade_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Value)
                .HasColumnName("value")
                .IsRequired();

            builder.Property(x => x.StudentId)
                .HasColumnName("student_id")
                .IsRequired();

            builder.Property(x => x.DisciplineId)
                .HasColumnName("discipline_id")
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Discipline)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
