using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class ClassroomRegistrationStudent : Entity<StudentRegistrationID>
    {
        //variables
        public StudentRegistrationDetail RegistrationDetail { get; private set; }


        //constructor
        public ClassroomRegistrationStudent(StudentRegistrationID registrationID) : base(registrationID) { }


        //set method for registration detail
        public void SetRegistrationDetail(StudentRegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}
