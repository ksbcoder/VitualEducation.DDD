using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Events.Account
{
    public class AccountAddedEvent
    {
        //variables
        public AccountID AccountIDEvent { get; set; }
        //constructor
        public AccountAddedEvent(AccountID accountID)
        {
            this.AccountIDEvent = accountID;
        }
    }
}
