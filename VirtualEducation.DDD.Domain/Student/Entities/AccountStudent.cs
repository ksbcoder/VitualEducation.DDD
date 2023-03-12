using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class AccountStudent : Entity<AccountID>
    {
        //variables
        public AccountDetail AccountDetail { get; private set; }
        public Email Email { get; private set; }
        public Permissions Permissions { get; private set; }


        //constructor
        public AccountStudent(AccountID accountID) : base(accountID) { }


        //set method for account detail
        public void SetAccountDetail(AccountDetail accountDetail)
        {
            this.AccountDetail = accountDetail;
        }
        //set method for email
        public void SetEmail(Email email)
        {
            this.Email = email;
        }
        //set method for permissions
        public void SetPermissions(Permissions permissions)
        {
            this.Permissions = permissions;
        }
    }
}
