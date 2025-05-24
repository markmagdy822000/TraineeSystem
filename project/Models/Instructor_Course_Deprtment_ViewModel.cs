using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace project.Models
{
    public class Instructor_Course_Deprtment_ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        //[ForeignKey("Course")]
        //public virtual Course Course { get; set; }
        //[ForeignKey("Department")]
        //public virtual Department Department { get; set; }
        //public bool isDeleted { get; set; }

        //-- from Department----
        public int DepartmentId { get; set; }
        public List<Department> Departments{ get; set; }
        //-- from Course----
        public int CrsId { get; set; }
        public List<Course> Courses{ get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
