using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
        public List<Student> Students { get; set; }

    }
}
