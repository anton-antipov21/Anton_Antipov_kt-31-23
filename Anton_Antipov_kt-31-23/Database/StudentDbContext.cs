
using Microsoft.EntityFrameworkCore;
using Anton_Antipov_kt_31_23.Models;

namespace Anton_Antipov_kt_31_23.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Speciality> Specialities { get; set; } = null!;

        public DbSet<Group> Groups { get; set; } = null!;

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Discipline> Disciplines { get; set; } = null!;

        public DbSet<Grade> Grades { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(StudentDbContext).Assembly);
        }
    }
}
