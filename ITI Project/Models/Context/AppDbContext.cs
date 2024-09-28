using ITI_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ITI_Project.Models.ViewModel;

namespace ITI_Project.Models.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITIMVC;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }   
        public DbSet<Trainee>    Trainees { get; set; }
        public DbSet<Course>     Courses { get; set; }
        public DbSet<CrsResult>  CourseResule {  get; set; }
    }
}
