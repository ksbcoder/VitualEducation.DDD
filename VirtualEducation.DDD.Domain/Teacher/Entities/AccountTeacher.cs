using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class AccountTeacher : Entity<TeacherAccountID>
    {
        //variables
        public TeacherAccountDetail AccountDetail { get; private set; }
        public TeacherEmail Email { get; private set; }
        public TeacherPermissions Permissions { get; private set; }


        //constructor
        public AccountTeacher(TeacherAccountID accountID) : base(accountID) { }


        //set method for account detail 
        public void SetAccountDetail(TeacherAccountDetail accountDetail)
        {
            this.AccountDetail = accountDetail;
        }
        //set method for email
        public void SetEmail(TeacherEmail email)
        {
            this.Email = email;
        }
        //set method for permissions
        public void SetPermissions(TeacherPermissions permissions)
        {
            this.Permissions = permissions;
        }
    }
}
