
using Microsoft.EntityFrameworkCore;

namespace StudentSystem.Models
{
    public class ApplicationContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=StudentsDb;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True");
        protected override void OnModelCreating(ModelBuilder modelBuilder)=>base.OnModelCreating(modelBuilder);
            
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
