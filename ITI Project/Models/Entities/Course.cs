namespace ITI_Project.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Degree { get; set; }
        public float MinDegree { get; set; }
        public float Hours { get; set; }

        public int dept_id { get; set; }
        public Department Department { get; set; }=null!;
        public IEnumerable<CrsResult> CourseResult { get; set; } = new HashSet<CrsResult>();
        public IEnumerable<Instructor> instructors { get; set; } = new HashSet<Instructor>();
    }
}
