namespace VirtualEducation.DDD.Domain.Classroom.Commands.Teacher
{
    public class ClassroomAddTeacherCommand
    {
        public string ClassroomId { get; init; }
        public string TeacherId { get; init; }
    }
}
