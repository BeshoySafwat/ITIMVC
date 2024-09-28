using ITI_Project.Models.Context;
using ITI_Project.Models.Entities;
using ITI_Project.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Models.EntitiesBL
{
    public class CourseBL
    {
        AppDbContext app = new AppDbContext();
        public IQueryable<Course> GetAll()
        {
            var Crs = app.Courses.Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
                dept_id = c.dept_id
            });
            return Crs;
        }

        // Fetch all departments
        public List<Department> DepartList()
        {
            var Dep = app.Departments.Select(d => new Department
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
            return Dep;
        }
        public Inst_Dep_CrsViewModel GetViewModel()
        {
            // Create an instance of the view model
            Inst_Dep_CrsViewModel viewModel = new Inst_Dep_CrsViewModel();

            // Populate courses and departments in the view model
            viewModel.crs = GetAll().ToList(); // Fetch all courses
            viewModel.Dep = DepartList(); // Fetch all departments

            return viewModel; // Return the populated view model
        }

        public IQueryable<Course> GetCoursesByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Enumerable.Empty<Course>().AsQueryable();
            }

            return GetAll()
                      .Where(c => EF.Functions.Like(c.Name.Trim().ToLower(), $"%{name.Trim().ToLower()}%"));
        }

        public Course GetByID(int id)
        {
            var Courses = GetAll().First(c => c.Id == id);

            return Courses;
        }

        public void Add(Course crs)
        {
            app.Courses.Add(crs);
            app.SaveChanges();
        }

        public void Update(Course crs)
        {
            app.Courses.Update(crs);
            app.SaveChanges();
        }

        public void Delete(Course crs)
        {
            app.Courses.Remove(crs);
            app.SaveChanges();

        }
        public void Dispose()
        {
            app.Dispose();
        }

    }
}
