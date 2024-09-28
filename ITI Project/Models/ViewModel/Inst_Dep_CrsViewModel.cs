using ITI_Project.Models.Entities;

namespace ITI_Project.Models.ViewModel
{
    public class Inst_Dep_CrsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
        public string? Image { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public int department_id { get; set; }
        public int Course_id { get; set; }
        public float Degree { get; set; }
        public float MinDegree { get; set; }
        public float Hours { get; set; }

        public List<Department> Dep { get; set; }
        public List<Course> crs { get; set; }

        public static implicit operator Inst_Dep_CrsViewModel(Course c)
        {
            return new Inst_Dep_CrsViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
                department_id = c.dept_id
            };
        }

        public static implicit operator Course(Inst_Dep_CrsViewModel c)
        {
            return new Course
            {
                Id = c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
                dept_id = c.department_id
            };
        }

    }
}
