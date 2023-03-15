namespace VirtualEducation.DDD.Domain.Teacher.Commands.Teacher
{
    public class CreateTeacherCommand
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
        public string Gender { get; init; }
    }
}
