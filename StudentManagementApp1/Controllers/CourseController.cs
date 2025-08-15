using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp1.Data;
using StudentManagementApp1.Models;

namespace StudentManagementApp1.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbContext _context;
        public CourseController(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Courses.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
               await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(course);
        }

       
    }
}
