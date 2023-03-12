using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class StudentCreated : DomainEvent
    {
        public string StudentID { get; set; }

        public StudentCreated(string studentID) : base("student.created")
        {
            StudentID = studentID;
        }
    }
}
