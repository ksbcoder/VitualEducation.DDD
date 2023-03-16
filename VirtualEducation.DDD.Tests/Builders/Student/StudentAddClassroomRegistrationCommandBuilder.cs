using VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration;

namespace VirtualEducation.DDD.Tests.Builders.Student
{
    public class StudentAddClassroomRegistrationCommandBuilder
    {
        private string _studentId;
        private DateTime _registratedAt;
        public StudentAddClassroomRegistrationCommandBuilder WithStudentId(string studentId)
        {
            _studentId = studentId;
            return this;
        }
        public StudentAddClassroomRegistrationCommandBuilder WithCreatedAt(DateTime registratedAt)
        {
            _registratedAt = registratedAt;
            return this;
        }
        public StudentAddClassroomRegistrationCommand Build()
        {
            return new StudentAddClassroomRegistrationCommand(_studentId, _registratedAt);
        }
    }
}
