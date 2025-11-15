using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Configurations
{
    public class DepartmentSubjectConfigurations : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(ds => new { ds.SubID, ds.DID });

            builder.HasOne(ds => ds.Department)
            .WithMany(d => d.DepartmentSubjects)
            .HasForeignKey(ds => ds.DID);

            builder.HasOne(ds => ds.Subject)
            .WithMany(s => s.DepartmentsSubjects)
            .HasForeignKey(ds => ds.SubID);


        }
    }
}
