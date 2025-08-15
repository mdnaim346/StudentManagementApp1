using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp1.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        
        public  int  CourseId { get; set; }
        public  Course Course { get; set; }
    }
}
