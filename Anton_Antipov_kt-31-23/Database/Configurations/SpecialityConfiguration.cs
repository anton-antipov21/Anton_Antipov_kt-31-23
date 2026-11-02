
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Anton_Antipov_kt_31_23.Models;

namespace Anton_Antipov_kt_31_23.Database.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("specialities");

            builder.HasKey(x => x.SpecialityId);

            builder.Property(x => x.SpecialityId)
                .HasColumnName("speciality_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
