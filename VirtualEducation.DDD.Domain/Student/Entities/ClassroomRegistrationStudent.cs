using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class ClassroomRegistrationStudent
    {
        //variables
        public Guid RegistrationID { get; init; }
        public RegistrationDetail RegistrationDetail { get; private set; }
        //constructor
        public ClassroomRegistrationStudent(Guid id)
        {
            this.RegistrationID = id;
        }
        //set method for registration detail
        public void SetRegistrationDetail(RegistrationDetail registrationDetail)
        {
            this.RegistrationDetail = registrationDetail;
        }
    }
}
