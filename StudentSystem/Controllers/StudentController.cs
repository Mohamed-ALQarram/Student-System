using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;

namespace StudentSystem.Controllers
{
    public class StudentController : Controller
    {
        ApplicationContext context = new();
        public IActionResult StudentShow()
        {
            //context.Students.RemoveRange(context.Students.ToList());
            //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, 0);");
            //context.SaveChanges();

            return View(context.Students.Include(s=>s.Department).ToList());
        }
        public IActionResult CreateStudent()
        {
            var result = context.Departments.ToList();
            ViewBag.Depts = result;
            return View();
        }

        public IActionResult AddStudent(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
            return RedirectToAction("StudentShow");
        }

        public IActionResult EditStudent(int stdID)
        {
            var student = context.Students.FirstOrDefault(s => s.StudentID == stdID);
            ViewBag.Depts = context.Departments.ToList();
            return View(student);
        }

        public IActionResult UpdateStudent(Student std) 
        {
            var student = context.Students.FirstOrDefault(s=> s.StudentID== std.StudentID);
            if (student != null)
            {
                student.StudentName = std.StudentName;
                student.StudentAge = std.StudentAge;
                student.DepartmentID = std.DepartmentID;
                context.SaveChanges();
            }
            return RedirectToAction("StudentShow");
        }

        public IActionResult RemoveStudent(int studentID)
        {
            var std = context.Students.FirstOrDefault(s => s.StudentID == studentID);
            if (std != null)
            {
                context.Students.Remove(std);
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, {0});", context.Students.Count());
                context.SaveChanges();
            }
            return RedirectToAction("StudentShow");
        }

    }
}
