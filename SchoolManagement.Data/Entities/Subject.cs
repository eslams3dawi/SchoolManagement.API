using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Subject : GeneralLocalizableEntity
    {
        public int SubjectId { get; set; }
        public string SubjectNameEn { get; set; }
        public int? Period { get; set; }


        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();


        [InverseProperty(nameof(DepartmentSubject.Subject))]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>();


        [InverseProperty(nameof(InstructorSubject.Subject))]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();


        [InverseProperty(nameof(Assignment.Subject))]
        public virtual ICollection<Assignment> Assignments { get; set; } = new HashSet<Assignment>();


        [StringLength(200)]
        public string? SubjectNameAr { get; set; }
    }
}
