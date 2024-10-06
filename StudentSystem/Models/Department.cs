using System.Collections.ObjectModel;

namespace StudentSystem.Models
{
    public class Department
    {
        public Department() : this( "", new Collection<Student>()) { }
        public Department( string Name , ICollection<Student> students) 
        { 
            DeptName = Name;
            Students = students;
        }
        public int DepartmentID { get; set; }
        public string DeptName { get; set; }
        public virtual ICollection<Student> Students { get; set; }   
    }
}
