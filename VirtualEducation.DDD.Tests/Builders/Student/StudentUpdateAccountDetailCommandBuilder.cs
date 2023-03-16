using VirtualEducation.DDD.Domain.Student.Commands.Account;

namespace VirtualEducation.DDD.Tests.Builders.Student
{
    public class StudentUpdateAccountDetailCommandBuilder
    {
        private string _studentId;
        private string _username;
        private DateTime _createdAt;
        public StudentUpdateAccountDetailCommandBuilder WithStudentId(string studentId)
        {
            _studentId = studentId;
            return this;
        }

        public StudentUpdateAccountDetailCommandBuilder WithUsername(string username)
        {
            _username = username;
            return this;
        }

        public StudentUpdateAccountDetailCommandBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public StudentUpdateAccountDetailCommand Build()
        {
            return new StudentUpdateAccountDetailCommand(_studentId, _username);
        }
    }
}
