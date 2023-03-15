using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Entities;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountAdded : DomainEvent
    {
        public AccountStudent AccountStudent { get; set; }

        public AccountAdded(AccountStudent accountStudent) : base("student.account.added")
        {
            AccountStudent = accountStudent;
        }
    }
}
