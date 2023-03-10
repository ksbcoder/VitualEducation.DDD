using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class Teacher
    {
        //variables
        public Guid TeacherID { get; init; }
        public Guid AccountID { get; private set; }
        public Guid ClassroomRegistrationID { get; private set; }
        public PersonalData PersonalData { get; private set; }
        //virtual navigation
        [JsonIgnore]
        public virtual AccountTeacher? Account { get; private set; }
        public virtual ClassroomRegistrationTeacher? ClassroomRegistration { get; private set; }
        //constructor
        public Teacher(Guid id, AccountTeacher accountTeacher)
        {
            this.TeacherID = id;
            this.AccountID = accountTeacher.AccountID;
        }
        //set method for classroom registration id
        public void SetClassroomRegistrationID(RegistrationID registrationID)
        {
            this.ClassroomRegistrationID = registrationID;
        }
        //set method for personal data
        public void SetPersonalData(PersonalData personalData)
        {
            this.PersonalData = personalData;
        }
        //set method for account
        public void SetAccount(AccountTeacher accountTeacher)
        {
            this.Account = accountTeacher;
        }
        //set method for classroom registration
        public void SetClassroomRegistration(ClassroomRegistrationTeacher classroomRegistrationTeacher)
        {
            this.ClassroomRegistration = classroomRegistrationTeacher;
        }
    }
}
