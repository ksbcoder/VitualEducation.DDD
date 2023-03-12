using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public  class ClassroomRegistrationDetailAdded : DomainEvent
    {
        public TeacherRegistrationDetail ClassroomRegistrationDetail { get; set; }

        public ClassroomRegistrationDetailAdded(TeacherRegistrationDetail classroomRegistrationDetail)
            : base("teacher.classroomregistration.detail.added")
        {
            ClassroomRegistrationDetail = classroomRegistrationDetail;
        }
    }
}
