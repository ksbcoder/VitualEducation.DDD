using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class ClassroomRegistrationDetailAdded : DomainEvent
    {
        public RegistrationDetail ClassroomRegistrationDetail { get; set; }

        public ClassroomRegistrationDetailAdded(RegistrationDetail classroomRegistrationDetail)
            : base("student.classroomregistrationdetail.added")
        {
            ClassroomRegistrationDetail = classroomRegistrationDetail;
        }
    }
}
