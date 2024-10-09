using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Student
    {
        public int StudentID {  get; set; }
        public string? StudentName { get; set; }
        public byte StudentAge { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
