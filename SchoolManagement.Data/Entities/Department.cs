using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        public int DepartmentId { get; set; }
        public string NameEn { get; set; }
        public string? NameAr { get; set; }


        [InverseProperty(nameof(Student.Department))]//Students List Nav Prop. is inverse to the Nav Prop of Department in Student class
        public virtual ICollection<Student>? Students { get; set; } = new HashSet<Student>();

        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject>? DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>();


        public int? InstructorManager { get; set; }
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        [ForeignKey(nameof(InstructorManager))]
        public virtual Instructor? Manager { get; set; }


        [InverseProperty(nameof(Instructor.Department))]
        public virtual ICollection<Instructor>? Instructors { get; set; } = new HashSet<Instructor>();
    }
}
