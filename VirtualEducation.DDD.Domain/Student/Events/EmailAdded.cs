using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class EmailAdded : DomainEvent
    {
        public Email Email { get; set; }

        public EmailAdded(Email email) : base("student.account.email.added")
        {
            Email = email;
        }

    }
}
