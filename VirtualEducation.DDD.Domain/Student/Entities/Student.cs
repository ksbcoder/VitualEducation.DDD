using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class Student
    {
        //variables
        public Guid StudentID { get; init; }
        public Guid AccountID { get; private set; }
        public Guid ClassroomRegistrationID { get; private set; }
        public PersonalData PersonalData { get; private set; }
        //vitual navigation for entities
        [JsonIgnore]
        public virtual AccountStudent? Account { get; private set; }
        public virtual ClassroomRegistrationStudent? ClassroomRegistration { get; private set; }
        //constructor
        public Student(Guid id, AccountStudent accountStudent)
        {
            this.StudentID = id;
            this.AccountID = accountStudent.AccountID;
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
        public void SetAccount(AccountStudent accountStudent)
        {
            this.Account = accountStudent;
        }
        //set method for classroom registration
        public void SetClassroomRegistration(ClassroomRegistrationStudent classroomRegistrationStudent)
        {
            this.ClassroomRegistration = classroomRegistrationStudent;
        }
    }
}
