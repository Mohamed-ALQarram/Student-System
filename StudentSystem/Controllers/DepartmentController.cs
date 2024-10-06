using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;

namespace StudentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationContext context = new();
        public IActionResult DepartmentShow()
        {
            return View(context.Departments.Include(d=>d.Students).ToList());
        }
        public IActionResult CreateDepartment()
        {
            return View();
        }
        public IActionResult Add(Department Dept)
        {
            if(Dept.DeptName != null) 
            {
            context.Departments.Add(Dept);
            context.SaveChanges();
            }
            return RedirectToAction("DepartmentShow");
        }
        public IActionResult StudentShow(int DeptID)
        {
            var Dept = context.Departments.Include(d=>d.Students).FirstOrDefault(d=>d.DepartmentID==DeptID);
            return View(Dept);
        }
        public IActionResult RemoveDepartment(int DeptID)
        {
            var department = context.Departments.Include(d=>d.Students).FirstOrDefault(d => d.DepartmentID == DeptID);
            if (department != null)
            {
                if (department.Students.Count > 0)
                {
                    foreach (var std in department.Students)
                    {
                        std.DepartmentID = null;
                    } 
                context.SaveChanges();
                }
                context.Departments.Remove(department);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Departments', RESEED, {0});",context.Departments.Count());
            }
            return RedirectToAction("DepartmentShow");
        }

        public IActionResult EditDepartment(int deptID)
        {
            var dept = context.Departments.Include(d=>d.Students).FirstOrDefault(d => d.DepartmentID == deptID);
            return View(dept);
        }
        public ActionResult UpdateDepartment(Department dept)
        {
            var result = context.Departments.FirstOrDefault(d => d.DepartmentID == dept.DepartmentID);
            if (result != null)
            {
                result.DeptName = dept.DeptName;
                context.SaveChanges();
            }
            return RedirectToAction("DepartmentShow");
        }


    }
}
