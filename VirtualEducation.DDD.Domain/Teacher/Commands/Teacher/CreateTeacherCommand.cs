namespace VirtualEducation.DDD.Domain.Teacher.Commands.Teacher
{
    public class CreateTeacherCommand
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
        public string Gender { get; init; }

        public CreateTeacherCommand(string name, string lastName, int age, string gender)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
    }
}
