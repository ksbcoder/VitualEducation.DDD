namespace VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration
{
    public class StudentAddClassroomRegistrationCommand
    {
        public string StudentId { get; init; }
        public DateTime RegistratedAt { get; init; } = DateTime.UtcNow;
    }
}
