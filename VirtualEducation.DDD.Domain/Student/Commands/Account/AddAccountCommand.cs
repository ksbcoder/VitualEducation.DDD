namespace VirtualEducation.DDD.Domain.Student.Commands.Account
{
    public class StudentAddAccountCommand
    {

        public string StudentId { get; init; }
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }
        public string Role { get; init; }

        public StudentAddAccountCommand(string studentId, string username, DateTime createdAt, string personalMail, string institutionalMail, string role)
        {
            StudentId = studentId;
            Username = username;
            CreatedAt = createdAt;
            PersonalMail = personalMail;
            InstitutionalMail = institutionalMail;
            Role = role;
        }
    }
}
