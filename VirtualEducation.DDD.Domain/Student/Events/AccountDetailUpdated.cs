using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class AccountDetailUpdated : DomainEvent
    {
        public StudentAccountDetail AccountDetail { get; set; }

        public AccountDetailUpdated(StudentAccountDetail accountDetail) : base("student.account.detail.updated")
        {
            AccountDetail = accountDetail;
        }
    }
}
