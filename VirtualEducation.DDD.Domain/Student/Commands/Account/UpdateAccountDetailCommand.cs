namespace VirtualEducation.DDD.Domain.Student.Commands.Account
{
    public class UpdateAccountDetailCommand
    {
        public string StudentId { get; init; }
        public string Username { get; init; }
    }
}
