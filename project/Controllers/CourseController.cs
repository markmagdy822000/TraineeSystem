using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class CourseController : Controller
    {
        ITIMVCDBContext db=new ITIMVCDBContext();
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
        public IActionResult Add()
        {
            Course_Deparmtent_ViewModel crsVM=   new Course_Deparmtent_ViewModel();
            crsVM.Departments = db.Departments.Where(d=>d.isDeleted==false).ToList();
            return View("Add",crsVM);
        }
        public IActionResult SaveAdd(Course_Deparmtent_ViewModel crsForm)
        {
            Course crs = new Course();
            crs.Id = crsForm.Id;
            crs.DepartmentId = crsForm.DepartmentId;
            crs.Name = crsForm.Name;
            crs.Hours = crsForm.Hours;
            crs.Degree = crsForm.Degree;
            crs.MinDegree = crsForm.MinDegree;
            db.Courses.Add(crs);
            db.SaveChanges();   
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var crs= db.Courses.Where(c=>c.Id == id).FirstOrDefault();
            Course_Deparmtent_ViewModel crsVM = new Course_Deparmtent_ViewModel() { };
            crsVM.Id = crs.Id;
            crsVM.DepartmentId = crs.DepartmentId;
            crsVM.Name = crs.Name;
            crsVM.Hours = crs.Hours;
            crsVM.Degree = crs.Degree;
            crsVM.MinDegree = crs.MinDegree;

            crsVM.Departments = db.Departments.Where(d=>d.isDeleted==false).ToList();

            return View("Edit", crsVM);
        }

        public IActionResult SaveEdit(Course_Deparmtent_ViewModel crsForm) {
            if (crsForm?.Hours == 0 || crsForm?.Degree == 0 || crsForm?.Name==null) {
                return View("Edit", crsForm);
            }
            
            Course crs = db.Courses.Where(c=>c.Id == crsForm.Id).FirstOrDefault();
            crs.Id = crsForm.Id;
            crs.DepartmentId = crsForm.DepartmentId;
            crs.Name = crsForm.Name;
            crs.Hours = crsForm.Hours;
            crs.Degree = crsForm.Degree;
            crs.MinDegree = crsForm.MinDegree;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Course_Deparmtent_ViewModel crsForm)
        {
            Course crs = db.Courses.Where(c => c.Id == crsForm.Id).FirstOrDefault();
            db.Remove(crs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
