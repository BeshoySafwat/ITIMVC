using ITI_Project.Models.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="The Course Name Must Be Greter than 2")]
        [UniqeName]
        public string Name { get; set; } = null!;
        [Range(50,100,ErrorMessage ="The Course Degree Must Be Between 50 and 100")]
        public float Degree { get; set; }
        [Display(Name ="Min Degree")]
        [Range(20,60,ErrorMessage ="The Course Min Degree Must Be Between 20 and 60")]
        [Remote(action:"CheckDegree",controller:"Course",AdditionalFields ="Degree")]
        public float MinDegree { get; set; }
        public float Hours { get; set; }

        public int dept_id { get; set; }
        public Department Department { get; set; }=null!;
        public IEnumerable<CrsResult> CourseResult { get; set; } = new HashSet<CrsResult>();
        public IEnumerable<Instructor> instructors { get; set; } = new HashSet<Instructor>();
    }
}
