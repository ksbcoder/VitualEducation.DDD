using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class EmailAdded : DomainEvent
    {
        public TeacherEmail Email { get; set; }

        public EmailAdded(TeacherEmail email) : base("teacher.account.email.added")
        {
            Email = email;
        }
    }
}
