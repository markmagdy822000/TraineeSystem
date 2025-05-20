using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace project.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        [Column(TypeName ="money")]
        public decimal  Salary{ get; set; }
        public string Address{ get; set; }
        [ForeignKey("Course")]
        public int CrsId{ get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId{ get; set; }
        public virtual Department Department { get; set; }
        public bool isDeleted { get; set; }



    }
}
