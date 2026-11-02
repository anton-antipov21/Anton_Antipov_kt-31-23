
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Anton_Antipov_kt_31_23.Models;

namespace Anton_Antipov_kt_31_23.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable("disciplines");

            builder.HasKey(x => x.DisciplineId);

            builder.Property(x => x.DisciplineId)
                .HasColumnName("discipline_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
