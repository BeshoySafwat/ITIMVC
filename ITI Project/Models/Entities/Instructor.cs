namespace ITI_Project.Models.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Salaey { get; set; }
        public string? Image { get; set; } = null!;
        public string? Address { get; set; } = null!;

        public int dept_id { get; set; }
        public Department Department { get; set; }=null!;
        public int Crs_id { get; set; }
        public Course Course { get; set; }=null!;
    }
}
