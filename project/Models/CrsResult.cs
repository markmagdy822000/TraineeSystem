using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public bool isDeleted { get; set; }
    }
}
