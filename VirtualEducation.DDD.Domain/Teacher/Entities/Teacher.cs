using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.Events;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class Teacher : AggregateEvent<TeacherID>
    {
        //variables
        public TeacherID TeacherID { get; init; }
        public TeacherPersonalData PersonalData { get; private set; }
        //virtual navigation
        public virtual AccountTeacher AccountTeacher { get; private set; }
        public virtual ClassroomRegistrationTeacher ClassroomRegistrationTeacher { get; private set; }

        #region Metodos del agregado como manejador de eventos
        //Teacher
        public Teacher(TeacherID teacherID) : base(teacherID)
        {
            this.TeacherID = teacherID;
        }
        public void SetTeacherID(TeacherID studentID)
        {
            AppendChange(new TeacherCreated(studentID.ToString()));
        }
        public void SetPersonalData(TeacherPersonalData personalData)
        {
            AppendChange(new PersonalDataAdded(personalData));
        }
        //Account
        public void SetAccountToTeacher(AccountTeacher accountToTeacher)
        {
            AppendChange(new AccountAdded(accountToTeacher));
        }
        public void SetDetailsToAccount(TeacherAccountDetail accountDetail)
        {
            AppendChange(new AccountDetailAdded(accountDetail));
        }
        public void SetEmailToAccount(TeacherEmail email)
        {
            AppendChange(new EmailAdded(email));
        }
        public void SetPermissionsToAccount(TeacherPermissions permissions)
        {
            AppendChange(new PermissionsAdded(permissions));
        }
        public void SetEmailUpdatedToAccount(TeacherEmail email)
        {
            AppendChange(new EmailUpdated(email));
        }
        //Classroom
        public void SetClassroomRegistration(ClassroomRegistrationTeacher classroomRegistrationTeacher)
        {
            AppendChange(new ClassroomRegistrationAdded(classroomRegistrationTeacher));
        }
        public void SetDetailToClassroomRegistration(TeacherRegistrationDetail registrationDetail)
        {
            AppendChange(new ClassroomRegistrationDetailAdded(registrationDetail));
        }
        #endregion

        #region Metodos de cambio del agregado como entidad
        //Student
        public void SetPersonalDataAggregate(TeacherPersonalData personalData)
        {
            PersonalData = personalData;
        }
        //Account
        public void SetAccountAggregate(AccountTeacher accountTeacher) 
        {
            AccountTeacher = accountTeacher;
        }
        //Classroom
        public void SetClassroomRegistrationAggregate(ClassroomRegistrationTeacher classroomRegistrationTeacher)
        {
            ClassroomRegistrationTeacher = classroomRegistrationTeacher;
        }
        #endregion
    }
}
