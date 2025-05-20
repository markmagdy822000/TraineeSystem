using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
