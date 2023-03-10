namespace VirtualEducation.DDD.Domain.Student.Commands.Account
{
    public class AddAccountCommand
    {
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; }
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }
        public string Role { get; init; }

        public AddAccountCommand(string username, DateTime createdAt, string personalMail, string institutionalMail, string role)
        {
            this.Username = username;
            this.CreatedAt = createdAt;
            this.PersonalMail = personalMail;
            this.InstitutionalMail = institutionalMail;
            this.Role = role;
        }
    }
}
