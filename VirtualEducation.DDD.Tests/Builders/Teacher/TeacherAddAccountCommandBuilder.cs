using VirtualEducation.DDD.Domain.Teacher.Commands.Account;

namespace VirtualEducation.DDD.Tests.Builders.Teacher
{
    public class TeacherAddAccountCommandBuilder
    {
        private string _teacherId;
        private string _username;
        private DateTime _createdAt;
        private string _personalMail;
        private string _institutionalMail;
        private string _role;

        public TeacherAddAccountCommandBuilder WithTeacherId(string teacherId)
        {
            _teacherId = teacherId;
            return this;
        }

        public TeacherAddAccountCommandBuilder WithUserName(string accountId)
        {
            _username = accountId;
            return this;
        }

        public TeacherAddAccountCommandBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public TeacherAddAccountCommandBuilder WithPersonalMail(string personalMail)
        {
            _personalMail = personalMail;
            return this;
        }

        public TeacherAddAccountCommandBuilder WithInstitutionalMail(string institutionalMail)
        {
            _institutionalMail = institutionalMail;
            return this;
        }

        public TeacherAddAccountCommandBuilder WithRole(string role)
        {
            _role = role;
            return this;
        }
        public TeacherAddAccountCommand Build()
        {
            return new TeacherAddAccountCommand(_teacherId, _username, _createdAt, _personalMail, _institutionalMail, _role);
        }
    }
}
