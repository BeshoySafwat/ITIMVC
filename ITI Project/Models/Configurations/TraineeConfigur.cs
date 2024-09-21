using ITI_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Models.Configurations
{
    public class TraineeConfigur : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> T)
        {
            T.HasKey(c => c.Id);
            T.Property(t => t.Name).HasColumnType("varchar").HasMaxLength(50);
            T.Property(t => t.Address).HasColumnType("varchar").HasMaxLength(50);
            T.Property(t => t.Image).HasColumnType("varchar").HasMaxLength(50);


            T.HasOne(d => d.Department).WithMany(d => d.trainees)
                .HasForeignKey(t => t.dept_id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
