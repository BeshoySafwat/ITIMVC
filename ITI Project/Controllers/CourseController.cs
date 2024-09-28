using ITI_Project.Models.Entities;
using ITI_Project.Models.EntitiesBL;
using ITI_Project.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ITI_Project.Controllers
{
    public class CourseController : Controller
    {
        CourseBL courseBL = new CourseBL();
        public IActionResult Index()
        {
            var model = courseBL.GetViewModel();
            return View(model);
        }
        public IActionResult SearchByName(string name)
        {
            var viewModel = courseBL.GetViewModel();
            if (!string.IsNullOrWhiteSpace(name))
            {
                var filteredCourses = courseBL.GetCoursesByName(name).ToList();
                viewModel.crs = filteredCourses;
            }
            return View("Index", viewModel);
        }
        public IActionResult Details(int id)
        {
            var course = courseBL.GetByID(id);
            return View(course);
        }
        public IActionResult Delete(int id)
        {
            var i = courseBL.GetByID(id);
            courseBL.Delete(i);
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            var model = courseBL.GetViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Inst_Dep_CrsViewModel c)
        {

            if (ModelState.IsValid)
            {
                Course course = c;
                courseBL.Add(course);
                return RedirectToAction("Index");
            }
            var dep = courseBL.DepartList();
            c.Dep = dep;
            var courses = courseBL.GetAll().ToList();
            c.crs = courses;
            return View(c);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courseBL.Dispose();
            }
            base.Dispose(disposing);
        }
        // Ajax Call and return json
        public IActionResult CheckDegree(float MinDegree, float Degree)
        {
            if(Degree < MinDegree)
            {
                return Json("The Degree Muse Be Greter Than Min Degree");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
