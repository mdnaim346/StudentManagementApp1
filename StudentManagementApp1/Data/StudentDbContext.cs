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

    }
}
