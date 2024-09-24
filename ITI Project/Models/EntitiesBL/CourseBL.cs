using ITI_Project.Models.Context;
using ITI_Project.Models.Entities;
using ITI_Project.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Models.EntitiesBL
{
    public class CourseBL
    {
        AppDbContext app = new AppDbContext();


        public IEnumerable<Course>GetAll()
        {
            var Crs = app.Courses.Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
                dept_id=c.dept_id
            }).ToList();
            return Crs;
        }
        public IQueryable<Course>GetCoursesByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Enumerable.Empty<Course>().AsQueryable();
            }

            return app.Courses
                 .AsNoTracking()
                 .Where(i => EF.Functions.Like(i.Name.Trim().ToLower(), $"%{name.Trim().ToLower()}%"));
        }

        public Course GetByID(int id)
        {
            var result = app.Courses.Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
                dept_id = c.dept_id
            }).First(x=>x.Id==id);
            return result;
        }
        public List<Department> DepartList()
        {
            var Dep = app.Departments.Select(d => new Department
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();
            return Dep;
        }

        public Inst_Dep_CrsViewModel viewModel()
        {
            Inst_Dep_CrsViewModel inst = new Inst_Dep_CrsViewModel();
            inst.Dep = DepartList();
            inst.crs = GetAll().ToList();

            return inst;
        }
        public void Add(Course crs)
        {
            app.Courses.Add(crs);
            app.SaveChanges();
            Dispose();
        }

        public void Update(Course crs)
        {
            app.Courses.Update(crs);
            app.SaveChanges();
            Dispose();
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
