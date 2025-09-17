using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class StudentSubjectConfigurations : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.
                HasKey(x => new { x.StudentId, x.SubjectId });

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.StudentId);
            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.SubjectId);

            builder
                .Property(x => x.Degree)
                .HasPrecision(4, 2);
        }
    }
}
