using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp1.Data;
using StudentManagementApp1.Models;

namespace StudentManagementApp1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

       public StudentController(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.students.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
