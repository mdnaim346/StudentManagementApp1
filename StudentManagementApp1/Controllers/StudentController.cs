using Microsoft.AspNetCore.Mvc;
using StudentManagementApp1.Models;

namespace StudentManagementApp1.Controllers
{
    public class StudentController : Controller
    {
       
        static List<Student> students= new List<Student>();
        public IActionResult Index()
        {
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            students.Add(student);
            return RedirectToAction("Index");
        }
    }
}
