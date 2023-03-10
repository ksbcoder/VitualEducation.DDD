using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class ClassroomRegistrationTeacher
    {
        //variables
        public Guid RegistrationID { get; init; }
        public RegistrationDetail RegistrationDetail { get; private set; }
        //constructor
        public ClassroomRegistrationTeacher(Guid id)
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
