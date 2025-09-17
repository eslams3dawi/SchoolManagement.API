using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class StudentAssignmentConfigurations : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder
                .HasKey(x => new { x.StudentId, x.AssignmentId });

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentAssignments)
                .HasForeignKey(x => x.StudentId);
            builder
                .HasOne(x => x.Assignment)
                .WithMany(x => x.StudentAssignments)
                .HasForeignKey(x => x.AssignmentId);

            builder
                .Property(x => x.StudentAssignmentUrl)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
