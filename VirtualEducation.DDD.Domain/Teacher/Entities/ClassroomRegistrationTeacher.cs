using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class ClassroomRegistrationTeacher
    {
        //variables
        public TeacherRegistrationID RegistrationID { get; private set; }
        public TeacherRegistrationDetail RegistrationDetail { get; private set; }


        //constructor
        public ClassroomRegistrationTeacher(TeacherRegistrationID registrationID)
        {
            this.RegistrationID = registrationID;
        }


        //set method for registration detail
        public void SetRegistrationDetail(TeacherRegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}
