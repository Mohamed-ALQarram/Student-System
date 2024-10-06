using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Student
    {
        public Student():this( string.Empty , 0 , default) { }
        public Student( string Name , byte Age  ,Department? department)
        {
            StudentName = Name;
            StudentAge = Age;
            Department = department;
        }
        public int StudentID {  get; set; }
        public string StudentName { get; set; }
        public byte StudentAge { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
