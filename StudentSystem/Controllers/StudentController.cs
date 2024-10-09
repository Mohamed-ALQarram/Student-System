using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;
using StudentSystem.Repository;

namespace StudentSystem.Controllers
{
    public class StudentController : Controller
    {
        //ApplicationContext context = new();
        StudentRepo studentRepo;
        DepartmentRepo DeptRepo;
        public StudentController()
        {
            studentRepo = new StudentRepo();
            DeptRepo = new DepartmentRepo();
        }
        public IActionResult StudentShow()
        {
            //context.Students.RemoveRange(context.Students.ToList());
            //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, 0);");
            //context.SaveChanges();

            //return View(context.Students.Include(s=>s.Department).ToList());
            return View(studentRepo.GetAll());
        }
        public IActionResult CreateStudent()
        {
            //var result = context.Departments.ToList();
            //ViewBag.Depts = result;
            ViewBag.Depts = DeptRepo.GetAll();
            return View();
        }

        public IActionResult AddStudent(Student std)
        {
            //context.Students.Add(std);
            //context.SaveChanges();
            studentRepo.Add(std);
            studentRepo.Save();
            return RedirectToAction("StudentShow");
        }

        public IActionResult EditStudent(int StudentID)
        {
            //var student = context.Students.FirstOrDefault(s => s.StudentID == stdID);
            //ViewBag.Depts = context.Departments.ToList();
            ViewBag.Depts = DeptRepo.GetAll();
            var student = studentRepo.GetByID(StudentID);
            return View(student);
        }

        public IActionResult UpdateStudent(Student std) 
        {
            //var student = context.Students.FirstOrDefault(s=> s.StudentID== std.StudentID);
            if (std != null)
            {
                studentRepo.Update(std);
                studentRepo.Save();
            }
            return RedirectToAction("StudentShow");
        }

        public IActionResult RemoveStudent(int StudentID)
        {
            var std = studentRepo.GetByID(StudentID);
            if (std != null)
            {
                studentRepo.Delete(std);
                studentRepo.Save();
            }

            return RedirectToAction("StudentShow");
        }

    }
}
