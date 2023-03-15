using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.Entities;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class AccountAdded : DomainEvent
    {
        public AccountTeacher AccountTeacher { get; set; }

        public AccountAdded(AccountTeacher accountTeacher) : base("teacher.account.added")
        {
            this.AccountTeacher = accountTeacher;
        }
    }
}
