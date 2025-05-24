using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Trainee_Department_ViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        public int DepartmentId { get; set; }
        public virtual List<Department >Departments { get; set; }
        public bool isDeleted { get; set; }
    }
}
