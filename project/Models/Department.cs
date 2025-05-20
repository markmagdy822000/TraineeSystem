namespace project.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public virtual List<Instructor> Instructor { get; set; } = new List<Instructor>();
        public virtual List<Course> Course { get; set; } = new List<Course>();
        public virtual List<Trainee> Trainee { get; set; } = new List<Trainee>();
        public bool isDeleted { get; set; }

    }
}
