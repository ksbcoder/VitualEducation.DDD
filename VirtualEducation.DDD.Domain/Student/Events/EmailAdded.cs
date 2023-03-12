using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class EmailAdded : DomainEvent
    {
        public StudentEmail Email { get; set; }

        public EmailAdded(StudentEmail email) : base("student.account.email.added")
        {
            Email = email;
        }

    }
}
