using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class ClassroomRegistrationStudent
    {
        //variables
        public StudentRegistrationID RegistrationID { get; init; }
        public StudentRegistrationDetail RegistrationDetail { get; private set; }


        //constructor
        public ClassroomRegistrationStudent(StudentRegistrationID registrationID)
        {
            this.RegistrationID = registrationID;
        }


        //set method for registration detail
        public void SetRegistrationDetail(StudentRegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}
