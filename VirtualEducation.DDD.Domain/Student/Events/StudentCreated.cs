using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class StudentCreated : DomainEvent
    {
        public string StudentID { get; init; }

        public StudentCreated(string studentID) : base("student.created")
        {
            StudentID = studentID;
        }
    }
}
