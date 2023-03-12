namespace VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration
{
    public class AddClassroomRegistrationCommand
    {
        public string StudentId { get; init; }
        public DateTime RegistratedAt { get; init; } = DateTime.UtcNow;
    }
}
