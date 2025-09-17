using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(x => x.StudentId);
            builder
                .Property(x => x.FirstNameEn)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(x => x.FirstNameAr)
                .HasMaxLength(200);
            builder
                .Property(x => x.LastNameEn)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(x => x.LastNameAr)
                .HasMaxLength(200);
            builder
                .Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(13);
            builder
                .Property(x => x.AddressEn)
                .IsRequired()
                .HasMaxLength(300);
            builder
                .Property(x => x.AddressAr)
                .HasMaxLength(300);

            builder.HasData(
                new Student { StudentId = 1, FirstNameEn = "Omar", LastNameEn = "Mahmoud", AddressEn = "Cairo", Phone = "0101111111", DepartmentId = 1 },
                new Student { StudentId = 2, FirstNameEn = "Sara", LastNameEn = "Youssef", AddressEn = "Giza", Phone = "0102222222", DepartmentId = 2 },
                new Student { StudentId = 3, FirstNameEn = "Nour", LastNameEn = "Adel", AddressEn = "Alexandria", Phone = "0103333333", DepartmentId = 3 },
                new Student { StudentId = 4, FirstNameEn = "Ali", LastNameEn = "Mostafa", AddressEn = "Cairo", Phone = "0104444444", DepartmentId = 1 },
                new Student { StudentId = 5, FirstNameEn = "Mariam", LastNameEn = "Hassan", AddressEn = "Giza", Phone = "0105555555", DepartmentId = 2 },
                new Student { StudentId = 6, FirstNameEn = "Youssef", LastNameEn = "Ibrahim", AddressEn = "Alexandria", Phone = "0106666666", DepartmentId = 3 },
                new Student { StudentId = 7, FirstNameEn = "Dina", LastNameEn = "Khaled", AddressEn = "Cairo", Phone = "0107777777", DepartmentId = 1 },
                new Student { StudentId = 8, FirstNameEn = "Hassan", LastNameEn = "Omar", AddressEn = "Giza", Phone = "0108888888", DepartmentId = 2 },
                new Student { StudentId = 9, FirstNameEn = "Aya", LastNameEn = "Mohamed", AddressEn = "Alexandria", Phone = "0109999999", DepartmentId = 3 }
                );
        }
    }
}
