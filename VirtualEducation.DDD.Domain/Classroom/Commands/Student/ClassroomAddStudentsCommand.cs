namespace VirtualEducation.DDD.Domain.Classroom.Commands.Student
{
    public class ClassroomAddStudentCommand
    {
        public string ClassroomId { get; init; }
        public string StudentId { get; init; }
    }
}
