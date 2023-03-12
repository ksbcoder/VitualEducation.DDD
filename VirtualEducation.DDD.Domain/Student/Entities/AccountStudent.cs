using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Entities
{
    public class AccountStudent : Entity<StudentAccountID>
    {
        //variables
        public StudentAccountDetail AccountDetail { get; private set; }
        public StudentEmail Email { get; private set; }
        public StudentPermissions Permissions { get; private set; }


        //constructor
        public AccountStudent(StudentAccountID accountID) : base(accountID) { }


        //set method for account detail
        public void SetAccountDetail(StudentAccountDetail accountDetail)
        {
            this.AccountDetail = accountDetail;
        }
        //set method for email
        public void SetEmail(StudentEmail email)
        {
            this.Email = email;
        }
        //set method for permissions
        public void SetPermissions(StudentPermissions permissions)
        {
            this.Permissions = permissions;
        }
    }
}
