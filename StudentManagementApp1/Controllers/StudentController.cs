using System.Reflection.Metadata.Ecma335;
using AspNetCoreGeneratedDocument;
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.students.FindAsync(id);
            if ((student == null)) return NotFound();
            return View(student);


        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.ID) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var student = await _context.students.FirstOrDefaultAsync(m => m.ID == id);
            if ((student == null)) return NotFound();

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);

                await _context.SaveChangesAsync();
            }
           
            return RedirectToAction("Index");

        }
        private IActionResult NotFound()
        {
            return View();
        }
    }
}
