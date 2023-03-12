using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.Events;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Teacher.Entities.Rebuild
{
    public class TeacherRebuild
    {
        public Teacher CreateAggregate(List<DomainEvent> ev, TeacherID teacherID)
        {
            Teacher teacher = new(teacherID);
            //Add account to set your VOs
            if (ev.Find(e => e.GetType() == typeof(AccountAdded)) is AccountAdded accountAddedEvent)
            {
                teacher.SetAccountAggregate(accountAddedEvent.AccountTeacher);
            }
            //Add classroom registration to set your VOs
            if (ev.Find(e => e.GetType() == typeof(ClassroomRegistrationAdded)) 
                is ClassroomRegistrationAdded classroomRegistrationAddedEvent)
            {
                teacher.SetClassroomRegistrationAggregate(classroomRegistrationAddedEvent.ClassroomRegistration);
            }
            ev.ForEach(evento =>
            {
                switch (evento)
                {
                    //teacher
                    case PersonalDataAdded personalDataAdded:
                        teacher.SetPersonalDataAggregate(personalDataAdded.PersonalData);
                        break;
                    //account
                    case AccountDetailAdded accountDetailAdded:
                        teacher.AccountTeacher.SetAccountDetail(accountDetailAdded.AccountDetail);
                        break;
                    case EmailAdded emailAdded:
                        teacher.AccountTeacher.SetEmail(emailAdded.Email);
                        break;
                    case PermissionsAdded permissionsAdded:
                        teacher.AccountTeacher.SetPermissions(permissionsAdded.Permissions);
                        break;
                    case EmailUpdated emailUpdated:
                        teacher.AccountTeacher.SetEmail(emailUpdated.Email);
                        break;
                    //classroom
                    case ClassroomRegistrationDetailAdded classroomRegistrationDetailAdded:
                        teacher.ClassroomRegistrationTeacher.SetRegistrationDetail(
                            classroomRegistrationDetailAdded.ClassroomRegistrationDetail);
                        break;
                }
            });
            return teacher;
        }
    }
}
