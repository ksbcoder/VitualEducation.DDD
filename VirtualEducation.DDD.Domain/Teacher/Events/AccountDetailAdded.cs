using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class AccountDetailAdded : DomainEvent
    {
        public TeacherAccountDetail AccountDetail { get; set; }

        public AccountDetailAdded(TeacherAccountDetail accountDetail) : base("teacher.account.detail.added")
        {
            AccountDetail = accountDetail;
        }
    }
}
