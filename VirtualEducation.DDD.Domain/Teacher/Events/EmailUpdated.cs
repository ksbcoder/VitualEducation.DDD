using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class EmailUpdated : DomainEvent
    {
        public TeacherEmail Email { get; set; }

        public EmailUpdated(TeacherEmail email) : base("teacher.account.email.updated")
        {
            this.Email = email;
        }
    }
}
