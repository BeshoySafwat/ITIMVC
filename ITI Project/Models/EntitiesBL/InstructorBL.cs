using Humanizer;
using ITI_Project.Models.Context;
using ITI_Project.Models.Entities;
using ITI_Project.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ITI_Project.Models.EntitiesBL
{
    public class InstructorBL : IDisposable
    {
        AppDbContext app = new AppDbContext();


        public IEnumerable<Instructor> GetAll()
        {
            var result =app.Instructors.ToList();
            return result;
        }
        public IQueryable<Instructor> GetInstructorsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Enumerable.Empty<Instructor>().AsQueryable();
            }

            return app.Instructors
                 .AsNoTracking()
                 .Where(i => EF.Functions.Like(i.Name.Trim().ToLower(), $"%{name.Trim().ToLower()}%"));
        }

        public Instructor GetByID(int id)
        {
            var result =app.Instructors.Find(id);
            //Dispose();
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
        public List<Course> CrsList()
        {
            var crs = app.Courses.Select(d => new Course
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();
            return crs;
        }
        public Inst_Dep_CrsViewModel instviewModel()
        {
            Inst_Dep_CrsViewModel inst = new Inst_Dep_CrsViewModel();
            inst.Dep=DepartList();
            inst.crs=CrsList();
           
            return inst;
        }
        public void Add(Instructor instructor)
        {
            app.Instructors.Add(instructor);
            app.SaveChanges();
            Dispose();          
        }

        public void Update(Instructor ins)
        {
            app.Instructors.Update(ins);
            app.SaveChanges();
            Dispose();
        }

        public void Delete(Instructor instructor)
        {
            app.Instructors.Remove(instructor);
            app.SaveChanges();
            
        }
        public void Dispose()
        {
            app.Dispose();
        }

    }
}
