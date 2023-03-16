namespace VirtualEducation.DDD.Domain.Classroom.Commands.Classroom
{
    public class CreateClassroomCommand
    {

        public bool Notifications { get; init; }

        public CreateClassroomCommand(bool notifications)
        {
            Notifications = notifications;
        }
    }
}
