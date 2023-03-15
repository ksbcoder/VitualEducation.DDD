using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class StudentAdded : DomainEvent
    {
        public StudentID StudentID { get; init; }
        public StudentAdded(StudentID studentID) : base("classroom.student.added")
        {
            StudentID = studentID;
        }
    }
}
