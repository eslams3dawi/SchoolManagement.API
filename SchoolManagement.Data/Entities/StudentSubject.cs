using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class StudentSubject : GeneralLocalizableEntity
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public decimal? Degree { get; set; }

        [InverseProperty(nameof(Student.StudentSubjects))]
        [ForeignKey(nameof(StudentId))]
        public virtual Student? Student { get; set; }


        [InverseProperty(nameof(Subject.StudentSubjects))]
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject? Subject { get; set; }
    }
}
