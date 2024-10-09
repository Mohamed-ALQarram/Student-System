using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;
using System.Linq;

namespace StudentSystem.Repository
{
    public class DepartmentRepo
    {
        ApplicationContext context;
        public DepartmentRepo()
        {
            context = new ApplicationContext();
        }
        //CRUD Operations 
        public void Add(Department Dept)
        {
            context.Add(Dept);
        }
        public List<Department> GetAll()
        {
            return context.Departments.Include(d=>d.Students).ToList();
        }
        public Department? GetByID(int id)
        {
            return context.Departments.Include(d=>d.Students).FirstOrDefault(d=>d.DepartmentID==id);
        }
        public void Update(Department Dept)
        {
            context.Update(Dept);
        }
        public void Delete(Department Dept)
        {
            if (Dept != null)
            {
                context.Remove(Dept);
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, {0});", context.Departments.Count());
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
