using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Protocol;
using project.Models;

namespace project.Controllers
{
    public class TraineeController : Controller
    {
       
        ITIMVCDBContext db;
        CrsResult_Course_Trainee_ViewModel crsResult_Course_Trainee_ViewModel;
        public TraineeController()
        {
            db = new ITIMVCDBContext();
        }
        public IActionResult Index()
        {
            //db = new ITIMVCDBContext();
            var result = db.Trainees.Where(t=>t.isDeleted==false).ToList();

            return View("Index", result);
        }
       

        public IActionResult Result(int tid, int cid)
        {
            //https://localhost:44381/Trainee/Result?tid=1&cid=1
            //db = new ITIMVCDBContext();
            var result = 
                db.Courses.Join(db.CrsResults, c => c.Id, cr => cr.CrsId,
              (c, cr) => new { c, cr })
              .Join(db.Trainees, old => old.cr.TraineeId, t => t.Id,
              (old, t) => new { old, t})
              .Where(s=>s.old.c.Id == cid && s.t.Id==tid && s.t.isDeleted == false)
              .SingleOrDefault();
              

            crsResult_Course_Trainee_ViewModel = new CrsResult_Course_Trainee_ViewModel();

            crsResult_Course_Trainee_ViewModel.Tr_Name = result?.t?.Name;
            crsResult_Course_Trainee_ViewModel.Tr_Image = result.t.Image;
            crsResult_Course_Trainee_ViewModel.Tr_Grade = result.t.Grade;


            crsResult_Course_Trainee_ViewModel.Crs_MinDegree = result.old.c.MinDegree;
            crsResult_Course_Trainee_ViewModel.Color = "green";
            if (result.old.cr.Degree < result.old.c.MinDegree)
                crsResult_Course_Trainee_ViewModel.Color = "red";

            crsResult_Course_Trainee_ViewModel.Crs_Result_Degree = result.old.cr.Degree;

            crsResult_Course_Trainee_ViewModel.Crs_Name = result.old.c.Name;

            return View("Result", crsResult_Course_Trainee_ViewModel);
        }
        public IActionResult GetCourses(int tid)
        {
            //https://localhost:44381/Trainee/GetCourses?tid=1&cid=3
            db = new ITIMVCDBContext();
            var result =
                db.Trainees.Where(t => t.Id == tid && t.isDeleted == false)
                .Join(db.CrsResults,
                t => t.Id, cr => cr.TraineeId,
                (t, cr) => new { t, cr })
                .Join(db.Courses,
                old => old.cr.CrsId, c => c.Id,
                (old, c) => new { old, c }
                ).ToList();
            
            List<CrsResult_Course_Trainee_ViewModel> crsResult_Course_Trainee_ViewModelList = new List<CrsResult_Course_Trainee_ViewModel> ();
            for (int i = 0; i<result.Count();i++)
            {
                CrsResult_Course_Trainee_ViewModel crsResult_Course_Trainee_ViewModel = new CrsResult_Course_Trainee_ViewModel();
                crsResult_Course_Trainee_ViewModel.Tr_Name= result[i].old.t.Name;
                crsResult_Course_Trainee_ViewModel.Tr_Grade= result[i].old.t.Grade;
                crsResult_Course_Trainee_ViewModel.Tr_Image= result[i].old.t.Image;
                crsResult_Course_Trainee_ViewModel.Tr_Grade= result[i].old.t.Grade;
                crsResult_Course_Trainee_ViewModel.Crs_Result_Degree= result[i].old.cr.Degree;
                crsResult_Course_Trainee_ViewModel.Crs_MinDegree= result[i].c.MinDegree;

                crsResult_Course_Trainee_ViewModel.Color = result[i].old.cr.Degree < result[i].c.MinDegree ? "red" : "green";
                crsResult_Course_Trainee_ViewModel.Crs_Name = result[i].c.Name;
                crsResult_Course_Trainee_ViewModelList.Add(crsResult_Course_Trainee_ViewModel);
            }


            return View("GetCourses", crsResult_Course_Trainee_ViewModelList);
        }
    }
}
