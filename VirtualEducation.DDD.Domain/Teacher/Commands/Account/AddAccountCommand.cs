namespace VirtualEducation.DDD.Domain.Teacher.Commands.Account
{
    public class TeacherAddAccountCommand
    {
        public string TeacherId { get; init; }
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }
        public string Role { get; init; }

        public TeacherAddAccountCommand(string teacherId, string username, DateTime createdAt, string personalMail, string institutionalMail, string role)
        {
            TeacherId = teacherId;
            Username = username;
            CreatedAt = createdAt;
            PersonalMail = personalMail;
            InstitutionalMail = institutionalMail;
            Role = role;
        }
    }
}
