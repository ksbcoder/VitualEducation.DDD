using VirtualEducation.DDD.Domain.Classroom.Commands.Classroom;

namespace VirtualEducation.DDD.Tests.Builders.Classroom
{
    public class CreateClassroomCommandBuilder
    {
        private bool _notifications;
        public CreateClassroomCommandBuilder WithNotifications(bool notifications)
        {
            _notifications = notifications;
            return this;
        }
        public CreateClassroomCommand Build()
        {
            return new CreateClassroomCommand(_notifications);
        }
    }
}
