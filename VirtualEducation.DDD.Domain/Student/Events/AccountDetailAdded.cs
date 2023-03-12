using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountDetailAdded : DomainEvent
    {
        public AccountDetail AccountDetail { get; set; }

        public AccountDetailAdded(AccountDetail accountDetail) : base("student.account.detail.added")
        {
            AccountDetail = accountDetail;
        }
    }
}
