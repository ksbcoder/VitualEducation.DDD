using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountDetailUpdated : DomainEvent
    {
        public AccountDetail AccountDetail { get; set; }

        public AccountDetailUpdated(AccountDetail accountDetail) : base("student.account.detail.updated")
        {
            AccountDetail = accountDetail;
        }
    }
}
