using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountDetailAdded : DomainEvent
    {
        public StudentAccountDetail AccountDetail { get; set; }

        public AccountDetailAdded(StudentAccountDetail accountDetail) : base("student.account.detail.added")
        {
            AccountDetail = accountDetail;
        }
    }
}
