using Exams.Models;
using Microsoft.EntityFrameworkCore;

namespace Exams.DB
{
    public class ExamsContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }

        public ExamsContext(DbContextOptions<ExamsContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers);

            modelBuilder.Entity<ExamResult>()
                .HasOne(e => e.Student)
                .WithMany(s => s.ExamResults)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<ExamResult>()
                .HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<ExamResult>()
                .HasOne(e => e.Subject)
                .WithMany()
                .HasForeignKey(e => e.SubjectId);
        }
    }
}
