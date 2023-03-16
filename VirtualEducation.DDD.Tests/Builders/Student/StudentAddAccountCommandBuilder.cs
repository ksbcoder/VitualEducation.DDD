using VirtualEducation.DDD.Domain.Student.Commands.Account;

namespace VirtualEducation.DDD.Tests.Builders.Student
{
    public class StudentAddAccountCommandBuilder
    {
        private string _studentId;
        private string _username;
        private DateTime _createdAt;
        private string _personalMail;
        private string _institutionalMail;
        private string _role;

        public StudentAddAccountCommandBuilder WithStudentId(string studentId)
        {
            _studentId = studentId;
            return this;
        }
        public StudentAddAccountCommandBuilder WithUserName(string accountId)
        {
            _username = accountId;
            return this;
        }
        public StudentAddAccountCommandBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
        public StudentAddAccountCommandBuilder WithPersonalMail(string personalMail)
        {
            _personalMail = personalMail;
            return this;
        }
        public StudentAddAccountCommandBuilder WithInstitutionalMail(string institutionalMail)
        {
            _institutionalMail = institutionalMail;
            return this;
        }
        public StudentAddAccountCommandBuilder WithRole(string role)
        {
            _role = role;
            return this;
        }
        public StudentAddAccountCommand Build()
        {
            return new StudentAddAccountCommand(_studentId, _username, _createdAt, _personalMail, _institutionalMail, _role);
        }
    }
}
