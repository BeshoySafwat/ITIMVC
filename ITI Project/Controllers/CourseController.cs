using ITI_Project.Models.EntitiesBL;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    public class CourseController : Controller
    {
        CourseBL courseBL = new CourseBL();
        public IActionResult Index()
        {
            var courses = courseBL.GetAll();
            return View(courses);
        }
        public IActionResult SearchByName(string name)
        {
            return View("Index", courseBL.GetCoursesByName(name));
        }
        public IActionResult Details(int id)
        {
            var course = courseBL.GetByID(id);
            return View(course);
        }
        public IActionResult Add()
        {
            return View(courseBL.DepartList());
        }
        public IActionResult Delete(int id)
        {
            var i = courseBL.GetByID(id);
            courseBL.Delete(i);
            return RedirectToAction("Index");
        }
    }
}
