using ITI_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Models.Configurations
{
    public class CrsResultConfigur : IEntityTypeConfiguration<CrsResult>
    {
        public void Configure(EntityTypeBuilder<CrsResult> CS)
        {
            CS.HasKey(x => x.Id);

            CS.HasOne(t=>t.Trainee).WithMany(CS=>CS.CourseResult)
                .HasForeignKey(cs=>cs.Trainee_Id).OnDelete(DeleteBehavior.NoAction);
            CS.HasOne(c=>c.Course).WithMany(CS=>CS.CourseResult)
                .HasForeignKey(cs=>cs.CRS_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
