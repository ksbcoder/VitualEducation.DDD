namespace VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration
{
    public class TeacherAddClassroomRegistrationCommand
    {
        public string TeacherId { get; init; }
        public DateTime RegistratedAt { get; init; } = DateTime.UtcNow;
    }
}
