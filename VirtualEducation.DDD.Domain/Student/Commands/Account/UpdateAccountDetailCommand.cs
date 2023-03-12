namespace VirtualEducation.DDD.Domain.Student.Commands.Account
{
    public class StudentUpdateAccountDetailCommand
    {
        public string StudentId { get; init; }
        public string Username { get; init; }
    }
}
