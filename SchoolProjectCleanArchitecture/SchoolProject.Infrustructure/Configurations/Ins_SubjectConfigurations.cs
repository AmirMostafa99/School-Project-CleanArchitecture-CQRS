using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Configurations
{
    public class Ins_SubjectConfigurations : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(isub => new { isub.InsId, isub.SubId });

            builder.HasOne(isub => isub.instructor)
                .WithMany(i => i.Ins_Subjects)
                .HasForeignKey(isub => isub.InsId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(isub => isub.Subject)
                .WithMany(s => s.Ins_Subjects)
                .HasForeignKey(isub => isub.SubId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
