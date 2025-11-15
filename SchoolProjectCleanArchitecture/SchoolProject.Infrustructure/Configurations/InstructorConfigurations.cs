using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Configurations
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {

        public void Configure(EntityTypeBuilder<Instructor> builder)
        {


            builder.HasOne(i => i.supervisor)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
