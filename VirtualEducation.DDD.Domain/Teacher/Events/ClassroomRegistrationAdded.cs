using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.Entities;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class ClassroomRegistrationAdded : DomainEvent
    {
        public ClassroomRegistrationTeacher ClassroomRegistration { get; set; }

        public ClassroomRegistrationAdded(ClassroomRegistrationTeacher classroomRegistration)
            : base("teacher.classroomregistration.added")
        {
            ClassroomRegistration = classroomRegistration;
        }
    }
}
