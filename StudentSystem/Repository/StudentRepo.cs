using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;

namespace StudentSystem.Repository
{
    public class StudentRepo
    {
        ApplicationContext context;
        public StudentRepo()
        {
            context = new ApplicationContext();
        }
        //CRUD Operations 
        public void Add(Student std)
        {
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, {0});", context.Students.Count());
            Save();
            context.Add(std);   
        }
        public List<Student> GetAll()
        {
            return context.Students.Include(s=>s.Department).ToList();
        }
        public Student? GetByID(int id) 
        {
            return context.Students.FirstOrDefault(s=>s.StudentID == id);
        }
        public void Update(Student std)
        {
            context.Update(std);
        }
        public void Delete(Student std) 
        {
            if (std != null)
            {
                context.Students.Remove(std);
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
