using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class DepartmentSubject : GeneralLocalizableEntity
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }

        [InverseProperty(nameof(Department.DepartmentSubjects))]
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department? Department { get; set; }

        [InverseProperty(nameof(Subject.DepartmentSubjects))]
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject? Subject { get; set; }
    }
}
