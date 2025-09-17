using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class StudentAssignment : GeneralLocalizableEntity
    {
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string StudentAssignmentUrl { get; set; } //Student Upload


        [InverseProperty(nameof(Student.StudentAssignments))]
        public virtual Student? Student { get; set; }

        [InverseProperty(nameof(Assignment.StudentAssignments))]
        public virtual Assignment? Assignment { get; set; }
    }
}
