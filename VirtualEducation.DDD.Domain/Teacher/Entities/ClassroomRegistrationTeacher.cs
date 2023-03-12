using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class ClassroomRegistrationTeacher : Entity<TeacherRegistrationID>
    {
        //variables
        public TeacherRegistrationDetail RegistrationDetail { get; private set; }


        //constructor
        public ClassroomRegistrationTeacher(TeacherRegistrationID registrationID) : base(registrationID) { }


        //set method for registration detail
        public void SetRegistrationDetail(TeacherRegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}
