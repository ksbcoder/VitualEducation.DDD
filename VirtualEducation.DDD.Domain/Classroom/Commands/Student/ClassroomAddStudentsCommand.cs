namespace VirtualEducation.DDD.Domain.Classroom.Commands.Student
{
    public class ClassroomAddStudentsCommand
    {
        public string ClassroomId { get; init; }
        public string StudentId { get; init; }
    }
}
