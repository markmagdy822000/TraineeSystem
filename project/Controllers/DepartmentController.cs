using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Controllers
{
    public class DepartmentController : Controller
    {
        ITIMVCDBContext db;
        public DepartmentController()
        {
            db= new ITIMVCDBContext();
        }
        public IActionResult Index()
        {
            List<Department> result = db.Departments.Where(d=>d.isDeleted==false).ToList();
            return View("Index",result);
        }

        public IActionResult Add()
        {
            var result = new Department();
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(Department deptForm)
        {
            if(deptForm?.Name==null || deptForm?.ManagerName == null)
                return View("Add", deptForm);

            //db.SaveChanges();
            db.Departments.Add(deptForm);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Department dept = db.Departments.Where(d=>d.Id==id).FirstOrDefault();
            return View("Edit",dept);
        }
        [HttpPost]
        public IActionResult SaveEdit(Department deptForm)
        {
            Department dept = db.Departments.Where(d => d.Id == deptForm.Id).FirstOrDefault();
            dept.Name = deptForm.Name;  
            dept.ManagerName = deptForm.ManagerName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Department dept = db.Departments.Where(d => d.Id == id).FirstOrDefault();
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
