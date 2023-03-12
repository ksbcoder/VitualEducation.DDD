namespace VirtualEducation.DDD.Domain.Student.Commands.Account
{
    public class AddAccountCommand
    {
        public string StudentId { get; init; }
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }
        public string Role { get; init; }
    }
}
