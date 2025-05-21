using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace project.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        public virtual List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();
        public virtual List<Instructor> Instructor { get; set; } = new List<Instructor>();
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public bool isDeleted { get; set; }
    }
}
