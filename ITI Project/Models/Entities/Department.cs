namespace ITI_Project.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Manager { get; set; } 
        public IEnumerable<Instructor> instructors { get; set; }= new HashSet<Instructor>();
        public IEnumerable<Trainee> trainees { get; set; }= new HashSet<Trainee>();
        public IEnumerable<Course> courses { get; set; }= new HashSet<Course>();


    }
}
