using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class CourseController : Controller
    {
        ITIMVCDBContext db;
        public IActionResult Index()
        {
            db = new ITIMVCDBContext();
            var result = db.Courses.ToList();
            return View(result);
        }
        public IActionResult GetAllTrainees(int cid)
        {
        //https://localhost:44381/Course/GetAllTrainees?cid=1
            db = new ITIMVCDBContext();
            var result = db.Courses.Where(c => c.Id == cid && c.isDeleted == false)
                .Join(db.CrsResults, c => c.Id, cr => cr.CrsId,
                (c, cr) => new { c, cr })
                .Join(db.Trainees,
                old=>old.cr.TraineeId, t => t.Id,
                (old,t) => new { old,t})
                .ToList();

            List<CrsResult_Course_Trainee_ViewModel> crsResult_Course_Trainee_ViewModelList = new List<CrsResult_Course_Trainee_ViewModel>();

            for( int i = 0; i < result.Count(); i++)
            {
                CrsResult_Course_Trainee_ViewModel item = new CrsResult_Course_Trainee_ViewModel();
                item.Tr_Name = result[i].t.Name;
                item.Tr_Image = result[i].t.Image;

                item.Color = result[i].old.cr.Degree < result[i].old.c.MinDegree ? "red" : "green";

                item.Crs_MinDegree= result[i].old.c.MinDegree;
                item.Crs_Name = result[i].old.c.Name;
                item.Crs_Result_Degree = result[i].old.cr.Degree; 
                crsResult_Course_Trainee_ViewModelList.Add(item);
            }

            return View("GetAllTrainees",crsResult_Course_Trainee_ViewModelList);
        }
    }
}
