using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Events;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class Student : AggregateEvent<StudentID>
    {
        //variables
        public StudentID StudentID { get; init; }
        public StudentPersonalData PersonalData { get; private set; }
        //vitual navigation for entities
        public virtual AccountStudent AccountStudent { get; private set; }
        public virtual ClassroomRegistrationStudent ClassroomRegistrationStudent { get; private set; }


        #region Metodos del agregado como manejador de eventos
        //Student
        public Student(StudentID studentID) : base(studentID)
        {
            this.StudentID = studentID;
        }

        public void SetStudentID(StudentID studentID)
        {
            AppendChange(new StudentCreated(studentID.ToString()));
        }
        public void SetPersonalData(StudentPersonalData personalData)
        {
            AppendChange(new PersonalDataAdded(personalData));
        }
        //Account
        public void SetAccountToStudent(AccountStudent accountToStudent)
        {
            AppendChange(new AccountAdded(accountToStudent));
        }

        public void SetDetailsToAccount(StudentAccountDetail accountDetail)
        {
            AppendChange(new AccountDetailAdded(accountDetail));
        }

        public void SetEmailToAccount(StudentEmail email)
        {
            AppendChange(new EmailAdded(email));
        }

        public void SetPermissionsToAccount(StudentPermissions permissions)
        {
            AppendChange(new PermissionsAdded(permissions));
        }

        public void SetAccountDetailUpdatedToAccount(StudentAccountDetail accountDetail)
        {
            AppendChange(new AccountDetailUpdated(accountDetail));
        }
        //Classroom
        public void SetClassroomRegistration(ClassroomRegistrationStudent classroomRegistrationStudent)
        {
            AppendChange(new ClassroomRegistrationAdded(classroomRegistrationStudent));
        }
        public void SetDetailToClassroomRegistration(StudentRegistrationDetail registrationDetail)
        {
            AppendChange(new ClassroomRegistrationDetailAdded(registrationDetail));
        }

        #endregion

        #region Metodos de cambio del agregado como entidad
        //Student
        public void SetPersonalDataAggregate(StudentPersonalData personalData)
        {
            PersonalData = personalData;
        }
        //Account
        public void SetAccountAggregate(AccountStudent accountStudent)
        {
            AccountStudent = accountStudent;
        }
        //Classroom
        public void SetClassroomRegistrationAggregate(ClassroomRegistrationStudent classroomRegistrationStudent)
        {
            ClassroomRegistrationStudent = classroomRegistrationStudent;
        }
        #endregion
    }
}
