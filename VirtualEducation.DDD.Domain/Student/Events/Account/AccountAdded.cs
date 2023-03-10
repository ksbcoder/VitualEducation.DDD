using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events.Account
{
    public class AccountAdded
    {
        public Guid AccountID { get; init; }
        public AccountDetail AccountDetail { get; private set; }
        public Email Email { get; private set; }
        public Permissions Permissions { get; private set; }
    }
}
