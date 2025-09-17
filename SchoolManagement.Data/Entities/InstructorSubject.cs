using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class InstructorSubject : GeneralLocalizableEntity
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }


        [InverseProperty(nameof(Subject.InstructorSubjects))]
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject? Subject { get; set; }

        [InverseProperty(nameof(Instructor.InstructorSubjects))]
        [ForeignKey(nameof(InstructorId))]
        public virtual Instructor? Instructor { get; set; }
    }
}
