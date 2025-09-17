using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class SubjectConfigurations : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(x => x.SubjectId);
            builder
                .Property(x => x.SubjectNameEn)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(x => x.SubjectNameAr)
                .HasMaxLength(100);
            builder
                .Property(x => x.Period)
                .IsRequired();

            builder.HasData(
                    new Subject { SubjectId = 1, SubjectNameEn = "Algorithms", SubjectNameAr = "الخوارزميات", Period = 3 },
                    new Subject { SubjectId = 2, SubjectNameEn = "Databases", SubjectNameAr = "قواعد البيانات", Period = 4 },
                    new Subject { SubjectId = 3, SubjectNameEn = "Linear Algebra", SubjectNameAr = "الجبر الخطي", Period = 2 }
                );
        }
    }
}
