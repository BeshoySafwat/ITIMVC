namespace ITI_Project.Models.Entities
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Address { get; set; } = null!;
        public float Grade {  get; set; }

        public int dept_id { get; set; }
        public Department Department { get; set; } = null!;
        public IEnumerable<CrsResult> CourseResult { get; set; } = new HashSet<CrsResult>();


    }
}
