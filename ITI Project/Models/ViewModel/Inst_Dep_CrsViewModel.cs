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
        public int dept_id { get; set; }
        public int Crs_id { get; set; }

        public List<Department> Dep { get; set; }
        public List<Course> crs { get; set; }
    }
}
