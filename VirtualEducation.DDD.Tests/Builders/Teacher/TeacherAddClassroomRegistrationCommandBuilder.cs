using VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration;

namespace VirtualEducation.DDD.Tests.Builders.Teacher
{
    public class TeacherAddClassroomRegistrationCommandBuilder
    {
        private string _teacherId;
        private DateTime _registratedAt;
        public TeacherAddClassroomRegistrationCommandBuilder WithTeacherId(string teacherId)
        {
            _teacherId = teacherId;
            return this;
        }
        public TeacherAddClassroomRegistrationCommandBuilder WithCreatedAt(DateTime registratedAt)
        {
            _registratedAt = registratedAt;
            return this;
        }
        public TeacherAddClassroomRegistrationCommand Build()
        {
            return new TeacherAddClassroomRegistrationCommand(_teacherId, _registratedAt);
        }
    }
}
