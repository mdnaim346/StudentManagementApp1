using Microsoft.EntityFrameworkCore;
using StudentManagementApp1.Models;
namespace StudentManagementApp1.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
