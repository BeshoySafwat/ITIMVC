using ITI_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Models.Configurations
{
    public class InstructorConfigur : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> I)
        {
            I.HasKey(i=> i.Id);
            I.Property(i => i.Name).HasColumnType("varchar").HasMaxLength(50);
            I.Property(i => i.Image).HasColumnType("varchar").HasMaxLength(50);
            I.Property(i => i.Salary).HasColumnType("decimal(12 , 2)");
            I.Property(i => i.Address).HasColumnType("varchar").HasMaxLength(50);

            I.HasOne(d => d.Department).WithMany(i => i.instructors)
                .HasForeignKey(i => i.dept_id ).OnDelete(DeleteBehavior.NoAction);

            I.HasOne(c => c.Course).WithMany(i => i.instructors)
                .HasForeignKey(i => i.Crs_id ).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
