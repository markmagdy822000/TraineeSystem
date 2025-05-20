using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class CrsResult_Course_Trainee_ViewModel
    {
        //----- From Course ----
        public int Crs_Id { get; set; }
        public string Crs_Name { get; set; }
        public int? Crs_Degree { get; set; }
        public int Crs_MinDegree { get; set; }
        public int Crs_Hours { get; set; }
        //public virtual List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();
        //public virtual List<Instructor> Instructor { get; set; } = new List<Instructor>();
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }
        //public virtual Department Department { get; set; }
        //public bool isDeleted { get; set; }

        //----- From Trainee ----
        public int Tr_Id { get; set; }
        public string Tr_Name { get; set; }
        public string? Tr_Image { get; set; }
        public string Tr_Address { get; set; }
        public int Tr_Grade { get; set; }
        //[ForeignKey("Department")] public int DepartmentId { get; set; }
        //public virtual Department Department { get; set; }
        //public virtual List<CrsResult> CrsResult { get; set; } = new List<CrsResult>();
        //public bool isDeleted { get; set; }

        //----- From CrsRsult ----
        public int Crs_Result_Id { get; set; }
        public int Crs_Result_Degree { get; set; }
        //[ForeignKey("Course")]
        //public int CrsId { get; set; }
        //public virtual Course Course { get; set; }
        //[ForeignKey("Trainee")]
        //public int TraineeId { get; set; }
        //public virtual Trainee Trainee { get; set; }
        //public bool isDeleted { get; set; }
        public string Color{ get; set; }

    }
}
