using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class ClassroomRegistrationDetailAdded : DomainEvent
    {
        public StudentRegistrationDetail ClassroomRegistrationDetail { get; set; }

        public ClassroomRegistrationDetailAdded(StudentRegistrationDetail classroomRegistrationDetail)
            : base("student.classroomregistration.detail.added")
        {
            ClassroomRegistrationDetail = classroomRegistrationDetail;
        }
    }
}
