using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(e => e.DID);
            builder.Property(e => e.DNameAr).HasMaxLength(500);

            builder.HasMany(d => d.Students)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DID)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Instructor)
           .WithOne(i => i.DepartmentManager)
           .HasForeignKey<Department>(i => i.InsMangerId)
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
