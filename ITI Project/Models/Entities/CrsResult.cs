namespace ITI_Project.Models.Entities
{
    public class CrsResult
    {
        public int Id { get; set; }
        public float Degree { get; set; }

        public int CRS_Id { get; set; }
        public Course Course { get; set; } = null!;

        public int Trainee_Id { get; set; }
        public Trainee Trainee { get; set; } = null!;
    }
}
