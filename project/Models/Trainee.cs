using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string?  Image{ get; set; }
        public string Address{ get; set; }
        public int Grade { get; set; }
        [ForeignKey("Department")]public int DepartmentId{ get; set; }
        public virtual Department Department { get; set; }
        public virtual List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();
        public bool isDeleted { get; set; }

    }
}
