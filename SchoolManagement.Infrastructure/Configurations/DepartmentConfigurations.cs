using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasKey(x => x.DepartmentId);

            builder
                .HasOne(x => x.Manager)
                .WithOne(x => x.DepartmentManager)
                .HasForeignKey<Department>(x => x.InstructorManager)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(x => x.NameAr)
                .HasMaxLength(200);

            builder.HasData(
                 new Department { DepartmentId = 1, NameEn = "Computer Science Department", NameAr = "قسم علوم الحاسب" },
                 new Department { DepartmentId = 2, NameEn = "Information Systems Department", NameAr = "قسم نظم المعلومات" },
                 new Department { DepartmentId = 3, NameEn = "Mathematics Department", NameAr = "قسم الرياضيات" }
                );
        }
    }
}
