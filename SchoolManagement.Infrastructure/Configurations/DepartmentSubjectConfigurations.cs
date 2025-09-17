using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class DepartmentSubjectConfigurations : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder
                .HasKey(x => new { x.DepartmentId, x.SubjectId });

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.DepartmentSubjects)
                .HasForeignKey(x => x.DepartmentId);
            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.DepartmentSubjects)
                .HasForeignKey(x => x.SubjectId);

            builder.HasData(
                new DepartmentSubject { DepartmentId = 1, SubjectId = 1 },
                new DepartmentSubject { DepartmentId = 1, SubjectId = 2 },
                new DepartmentSubject { DepartmentId = 2, SubjectId = 2 },
                new DepartmentSubject { DepartmentId = 3, SubjectId = 3 }
                );
        }
    }
}
