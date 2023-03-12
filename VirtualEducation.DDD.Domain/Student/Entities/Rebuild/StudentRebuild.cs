using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Events;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Entities.Rebuild
{
    public class StudentRebuild
    {
        public Student CreateAggregate(List<DomainEvent> ev, StudentID studentID)
        {
            Student student = new(studentID);
            //Add account to set your VOs
            if (ev.Find(e => e.GetType() == typeof(AccountAdded)) is AccountAdded accountAddedEvent)
            {
                student.SetAccountAggregate(accountAddedEvent.Account);
            }
            //Add classroom registration to set your VOs
            if (ev.Find(e => e.GetType() == typeof(ClassroomRegistrationAdded)) is ClassroomRegistrationAdded classroomRegistrationAddedEvent)
            {
                student.SetClassroomRegistrationAggregate(classroomRegistrationAddedEvent.ClassroomRegistration);
            }
            ev.ForEach(evento =>
            {
                switch (evento)
                {
                    //student
                    case PersonalDataAdded personalDataAdded:
                        student.SetPersonalDataAggregate(personalDataAdded.PersonalData);
                        break;
                    //account
                    case AccountDetailAdded accountDetailAdded:
                        student.AccountStudent.SetAccountDetail(accountDetailAdded.AccountDetail);
                        break;
                    case EmailAdded emailAdded:
                        student.AccountStudent.SetEmail(emailAdded.Email);
                        break;
                    case PermissionsAdded permissionsAdded:
                        student.AccountStudent.SetPermissions(permissionsAdded.Permissions);
                        break;
                    case AccountDetailUpdated accountDetailUpdated:
                        student.AccountStudent.SetAccountDetail(accountDetailUpdated.AccountDetail);
                        break;
                    //classroom
                    case ClassroomRegistrationDetailAdded classroomRegistrationDetailAdded:
                        student.ClassroomRegistrationStudent.SetRegistrationDetail(
                            classroomRegistrationDetailAdded.ClassroomRegistrationDetail);
                        break;
                }
            });
            return student;
        }
    }
}
