using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class AccountTeacher
    {
        //variables
        public Guid AccountID { get; init; }
        public AccountDetail AccountDetail { get; private set; }
        public Email Email { get; private set; }
        public Permissions Permissions { get; private set; }
        //constructor
        public AccountTeacher(Guid id)
        {
            this.AccountID = id;
        }
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
