using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;
using StudentSystem.Repository;

namespace StudentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        //ApplicationContext context = new();
        DepartmentRepo DeptRepo;
        public DepartmentController()
        {
            DeptRepo = new DepartmentRepo();
        }
        public IActionResult DepartmentShow()
        {
            //return View(context.Departments.Include(d=>d.Students).ToList());
            return View(DeptRepo.GetAll());
        }
        public IActionResult CreateDepartment()
        {
            return View();
        }
        public IActionResult Add(Department Dept)
        {
            if(Dept!= null) 
            {
            //context.Departments.Add(Dept);
            //context.SaveChanges();
            DeptRepo.Add(Dept);
            DeptRepo.Save();
            }
            return RedirectToAction("DepartmentShow");
        }
        public IActionResult StudentShow(int DeptID)
        {
            //var Dept = context.Departments.Include(d=>d.Students).FirstOrDefault(d=>d.DepartmentID==DeptID);
            return View(DeptRepo.GetByID(DeptID));
        }
        public IActionResult RemoveDepartment(int DeptID)
        {
            //var department = context.Departments.Include(d=>d.Students).FirstOrDefault(d => d.DepartmentID == DeptID);
            var Dept = DeptRepo.GetByID(DeptID);
            if (Dept != null)
            {
                if (Dept.Students?.Count > 0)
                {
                    foreach (var std in Dept.Students)
                    {
                        std.DepartmentID = null;
                    }
                    DeptRepo.Save();
                }
                //context.Departments.Remove(department);
                //context.SaveChanges();
                //context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Departments', RESEED, {0});",context.Departments.Count());
                DeptRepo.Delete(Dept);
                DeptRepo.Save();
            }
            return RedirectToAction("DepartmentShow");
        }

        public IActionResult EditDepartment(int DeptID)
        {
            var dept = DeptRepo.GetByID(DeptID);
            return View(dept);
        }
        public ActionResult UpdateDepartment(Department dept)
        {
            if (dept != null)
            {
                //context.Departments.Update(dept);
                //context.SaveChanges();
                DeptRepo.Update(dept);
                DeptRepo.Save();
            }
            return RedirectToAction("DepartmentShow");
        }


    }
}
