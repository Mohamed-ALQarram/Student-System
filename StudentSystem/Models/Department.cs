using System.Collections.ObjectModel;

namespace StudentSystem.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string? DeptName { get; set; }
        public virtual ICollection<Student>? Students { get; set; }   
    }
}
