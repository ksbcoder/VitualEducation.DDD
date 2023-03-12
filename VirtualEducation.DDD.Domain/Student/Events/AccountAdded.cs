using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Entities;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountAdded : DomainEvent
    {
        public AccountStudent Account { get; set; }

        public AccountAdded(AccountStudent account) : base("student.account.added")
        {
            Account = account;
        }
    }
}
