    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using project.Models;

namespace project.Controllers
{
    public class InstructorController : Controller
    {
       
        ITIMVCDBContext db = new ITIMVCDBContext();
        
        public InstructorController()
        {

        }
        public IActionResult Index()
        {
            List<Instructor> instructors = new List<Instructor>();
            instructors = db.Instructors.Where(i=>i.isDeleted==false).ToList();
            return View(instructors);
        }
        
        public IActionResult GetById(int id)
        {
            Instructor instructor = db.Instructors.Where(i => i.Id == id).FirstOrDefault();
            return View("GetById",instructor);
        }
        public IActionResult Add()
        {
            Instructor_Course_Deprtment_ViewModel ins = new Instructor_Course_Deprtment_ViewModel();
            ins.Departments = db.Departments.ToList();
            ins.Courses = db.Courses.ToList();

            return View("Add",ins);
        }
        [HttpPost]
        public IActionResult Add(Instructor_Course_Deprtment_ViewModel ins) {
            if ( ins?.Address==null || ins?.Name==null  )
                return View("Add",ins);

            Instructor newIns = new Instructor()
            {
                DepartmentId = ins.DepartmentId,
                Name = ins.Name,
                Salary = ins.Salary,
                CrsId= ins.CrsId,
                Address=ins.Address,
                Image = ins.Image,
            };
            db.Instructors.Add(newIns);
            db.SaveChanges();

           return RedirectToAction("Index");
        }   

        public IActionResult Edit(int id)
        {
            Instructor_Course_Deprtment_ViewModel ins = new Instructor_Course_Deprtment_ViewModel();
            Instructor oldIns = db.Instructors.Where(i => i.Id == id).FirstOrDefault();

           ins.Id = oldIns.Id ;
           ins.Name = oldIns.Name ;
           ins.Salary = oldIns.Salary ;
           ins.CrsId = oldIns.CrsId ;
           ins.Address = oldIns.Address ;
           ins.Image = oldIns.Image ;
           ins.DepartmentId = oldIns.DepartmentId;



            ins.Departments = db.Departments.Where(d=>d.isDeleted==false).ToList();
            ins.Courses = db.Courses.Where(c=>c.isDeleted==false).ToList();
            return View("Edit", ins);
        }
        [HttpPost]
        public IActionResult Edit(Instructor_Course_Deprtment_ViewModel insForm)
        {
            Instructor ins = db.Instructors.Where(i=>i.Id == insForm.Id).FirstOrDefault();
            if (ins?.Address == null || ins?.Name == null)
                return View("Edit", ins);

            ins.Id  = insForm.Id;
            ins.Name = insForm.Name;
            ins.Salary = insForm.Salary;
            ins.CrsId = insForm.CrsId;
            ins.Address=insForm.Address;
            ins.Image = insForm.Image;
            ins.DepartmentId = insForm.DepartmentId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        
        public IActionResult Delete(int id) {
            Instructor ins = db.Instructors.Where(i=>i.Id == id).SingleOrDefault();
            ins.isDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
