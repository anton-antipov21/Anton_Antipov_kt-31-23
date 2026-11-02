
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Anton_Antipov_kt_31_23.Models;

namespace Anton_Antipov_kt_31_23.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("groups");

            builder.HasKey(x => x.GroupId);

            builder.Property(x => x.GroupId)
                .HasColumnName("group_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("group_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Course)
                .HasColumnName("group_course")
                .IsRequired();

            builder.Property(x => x.SpecialityId)
                .HasColumnName("speciality_id")
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.Speciality)
                .WithMany(x => x.Groups)
                .HasForeignKey(x => x.SpecialityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
