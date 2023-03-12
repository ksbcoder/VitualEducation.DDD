using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class ClassroomRegistrationStudent : Entity<RegistrationID>
    {
        //variables
        public RegistrationDetail RegistrationDetail { get; private set; }


        //constructor
        public ClassroomRegistrationStudent(RegistrationID registrationID) : base(registrationID) { }


        //set method for registration detail
        public void SetRegistrationDetail(RegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}
