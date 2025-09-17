using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public int StudentId { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string? AddressEn { get; set; }
        public string? Phone { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Department.Students))]//Department Nav Prop. is inverse to the Nav Prop of list of student in Department class
        public virtual Department? Department { get; set; }


        [InverseProperty(nameof(StudentSubject.Student))]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();

        [InverseProperty(nameof(StudentAssignment.Student))]
        public virtual ICollection<StudentAssignment>? StudentAssignments { get; set; } = new HashSet<StudentAssignment>();


        [StringLength(100)]
        public string? FirstNameAr { get; set; }
        [StringLength(100)]
        public string? LastNameAr { get; set; }
        [StringLength(300)]
        public string? AddressAr { get; set; }
    }
}
