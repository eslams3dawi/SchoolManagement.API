using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Seeding
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            //Unary Relationship
            builder
                .HasOne(x => x.Supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasKey(x => x.InstructorId);
            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(x => x.FirstNameAr)
                .HasMaxLength(200);
            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(x => x.LastNameAr)
                .HasMaxLength(200);
            builder
                .Property(x => x.Salary)
                .IsRequired()
                .HasPrecision(8, 3);
            builder
                .Property(x => x.Degree)
                .IsRequired()
                .HasMaxLength(350);
            builder
                .Property(x => x.DegreeAr)
                .HasMaxLength(350);
            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(60);
            builder
                .Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(13);
            builder
                .Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(300);
            builder
                .Property(x => x.AddressAr)
                .HasMaxLength(300);

            builder.HasData(
                new Instructor { InstructorId = 1, FirstName = "Ahmed", LastName = "Ali", Salary = 60000m, Degree = "Professor", Email = "ahmed.ali@school.com", Phone = "0100000001", Address = "Cairo", DepartmentId = 1 },
                new Instructor { InstructorId = 2, FirstName = "Mona", LastName = "Hassan", Salary = 55000m, Degree = "Associate Professor", Email = "mona.hassan@school.com", Phone = "0100000002", Address = "Giza", DepartmentId = 2 },
                new Instructor { InstructorId = 3, FirstName = "Khaled", LastName = "Ibrahim", Salary = 50000m, Degree = "Assistant Professor", Email = "khaled.ibrahim@school.com", Phone = "0100000003", Address = "Alexandria", DepartmentId = 3 },
                new Instructor { InstructorId = 4, FirstName = "Layla", LastName = "Mostafa", Salary = 48000m, Degree = "Lecturer", Email = "layla.mostafa@school.com", Phone = "0100000004", Address = "Cairo", DepartmentId = 1 },
                new Instructor { InstructorId = 5, FirstName = "Omar", LastName = "Fathy", Salary = 47000m, Degree = "Lecturer", Email = "omar.fathy@school.com", Phone = "0100000005", Address = "Giza", DepartmentId = 2 },
                new Instructor { InstructorId = 6, FirstName = "Heba", LastName = "Adel", Salary = 46000m, Degree = "Assistant Lecturer", Email = "heba.adel@school.com", Phone = "0100000006", Address = "Alexandria", DepartmentId = 3 }
                );
        }
    }
}
