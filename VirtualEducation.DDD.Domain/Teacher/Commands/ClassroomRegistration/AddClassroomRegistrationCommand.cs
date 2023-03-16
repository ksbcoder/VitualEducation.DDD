namespace VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration
{
    public class TeacherAddClassroomRegistrationCommand
    {
        public string TeacherId { get; init; }
        public DateTime RegistratedAt { get; init; }

        public TeacherAddClassroomRegistrationCommand(string teacherId, DateTime registratedAt)
        {
            TeacherId = teacherId;
            RegistratedAt = registratedAt;
        }
    }
}
