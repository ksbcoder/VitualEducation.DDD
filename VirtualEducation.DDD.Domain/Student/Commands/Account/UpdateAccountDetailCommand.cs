namespace VirtualEducation.DDD.Domain.Student.Commands.Account
{
    public class StudentUpdateAccountDetailCommand
    {
        public string StudentId { get; init; }
        public string Username { get; init; }

        public StudentUpdateAccountDetailCommand(string studentId, string username)
        {
            StudentId = studentId;
            Username = username;
        }
    }
}
