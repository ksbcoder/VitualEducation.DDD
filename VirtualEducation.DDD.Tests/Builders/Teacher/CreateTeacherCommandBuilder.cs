using VirtualEducation.DDD.Domain.Teacher.Commands.Teacher;

namespace VirtualEducation.DDD.Tests.Builders.Teacher
{
    public class CreateTeacherCommandBuilder
    {
        private string _name;
        private string _lastName;
        private int _age;
        private string _gender;

        public CreateTeacherCommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CreateTeacherCommandBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CreateTeacherCommandBuilder WithAge(int age)
        {
            _age = age;
            return this;
        }

        public CreateTeacherCommandBuilder WithGender(string gender)
        {
            _gender = gender;
            return this;
        }

        public CreateTeacherCommand Build()
        {
            return new CreateTeacherCommand(_name, _lastName, _age, _gender);
        }
    }
}