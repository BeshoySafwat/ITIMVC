using ITI_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Models.Configurations
{
    public class DepartmentConfigur : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.HasKey(d => d.Id);
            D.Property(d => d.Name).HasColumnType("varchar").HasMaxLength(50);
            D.Property(d => d.Manager).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
