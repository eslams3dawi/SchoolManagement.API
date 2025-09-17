using SchoolManagement.Infrastructure.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Data.Entities
{
    public class Assignment : GeneralLocalizableEntity
    {
        public int AssignmentId { get; set; }
        public int SubjectId { get; set; }
        public string AssignmentUrl { get; set; } //Instructor Upload


        [InverseProperty(nameof(Subject.Assignments))]
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }


        [InverseProperty(nameof(StudentAssignment.Assignment))]
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; } = new HashSet<StudentAssignment>();
    }
}
