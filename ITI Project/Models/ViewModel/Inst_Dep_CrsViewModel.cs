using ITI_Project.Models.Attributes;
using ITI_Project.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models.ViewModel
{
    public class Inst_Dep_CrsViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The Course Name Must Be Greter than 2")]
        [UniqeName]
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
        public string? Image { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public int department_id { get; set; }
        public int? Course_id { get; set; }

        [Range(50, 100, ErrorMessage = "The Course Degree Must Be Between 50 and 100")]
        public float Degree { get; set; }

        [Display(Name = "Min Degree")]
        [Range(20, 60, ErrorMessage = "The Course Min Degree Must Be Between 20 and 60")]
        [Remote(action: "CheckDegree", controller: "Course", AdditionalFields = "Degree")]
        public float MinDegree { get; set; }
        public float Hours { get; set; }

        public List<Department>? Dep { get; set; }
        public List<Course>? crs { get; set; }

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
                Id = (int)c.Id,
                Name = c.Name,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Hours = c.Hours,
                dept_id = c.department_id
            };
        }

    }
}
