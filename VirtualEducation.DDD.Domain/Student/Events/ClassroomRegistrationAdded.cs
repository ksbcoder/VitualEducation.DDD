using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Entities;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class ClassroomRegistrationAdded : DomainEvent
    {
        public ClassroomRegistrationStudent ClassroomRegistration { get; set; }

        public ClassroomRegistrationAdded(ClassroomRegistrationStudent classroomRegistration)
            : base("student.classroomregistration.added")
        {
            ClassroomRegistration = classroomRegistration;
        }
    }
}
