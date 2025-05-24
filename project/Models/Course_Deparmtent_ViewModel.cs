using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Course_Deparmtent_ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        public bool isDeleted { get; set; }
      
    }
}
