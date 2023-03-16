using VirtualEducation.DDD.Domain.Teacher.Commands.Account;

namespace VirtualEducation.DDD.Tests.Builders.Teacher
{
    public class TeacherUpdateEmailCommandBuilder
    {
        private string _teacherId;
        private string _personalMail;
        public TeacherUpdateEmailCommandBuilder WithTeacherId(string teacherId)
        {
            _teacherId = teacherId;
            return this;
        }
        public TeacherUpdateEmailCommandBuilder WithPersonalEmail(string email)
        {
            _personalMail = email;
            return this;
        }
        public TeacherUpdateEmailCommand Build()
        {
            return new TeacherUpdateEmailCommand(_teacherId, _personalMail);
        }
    }
}
