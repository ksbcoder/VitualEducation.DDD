namespace VirtualEducation.DDD.Domain.Student.Commands.Student
{
    public class CreateStudentCommand
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
        public string Gender { get; init; }
    }
}
