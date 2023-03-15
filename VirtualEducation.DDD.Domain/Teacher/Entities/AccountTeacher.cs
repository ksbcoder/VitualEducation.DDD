using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Entities
{
    public class AccountTeacher
    {
        //variables
        public TeacherAccountID AccountID { get; private set; }
        public TeacherAccountDetail AccountDetail { get; private set; }
        public TeacherEmail Email { get; private set; }
        public TeacherPermissions Permissions { get; private set; }


        //constructor
        public AccountTeacher(TeacherAccountID accountID)
        {
            this.AccountID = accountID;
        }


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
