using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        //Instructor Teaches
        public int DepartmentId { get; set; }
        [InverseProperty(nameof(Department.Instructors))]
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        //Instructor Manages
        [InverseProperty(nameof(Department.Manager))]
        public virtual Department? DepartmentManager { get; set; }

        //Instructor Supervises
        public int? SupervisorId { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty(nameof(Instructors))]
        public virtual Instructor? Supervisor { get; set; }

        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection<Instructor>? Instructors { get; set; } = new HashSet<Instructor>();


        [InverseProperty(nameof(InstructorSubject.Instructor))]
        public virtual ICollection<InstructorSubject>? InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();

        public string? FirstNameAr { get; set; }
        public string? LastNameAr { get; set; }
        public string? DegreeAr { get; set; }
        public string? AddressAr { get; set; }
    }
}
