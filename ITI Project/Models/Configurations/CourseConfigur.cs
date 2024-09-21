using ITI_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITI_Project.Models.Configurations
{
    public class CourseConfigur : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> C)
        {
            C.HasKey(c => c.Id);
            C.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(50);

            C.HasOne(d => d.Department).WithMany(c => c.courses)
                .HasForeignKey(c => c.dept_id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
