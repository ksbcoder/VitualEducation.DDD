namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Student
{
    public class StudentPersonalData
    {
        //variables
        public string Name { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
        public string Gender { get; init; }


        //constructor
        public StudentPersonalData(string name, string lastName, int age, string gender)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }


        //create method
        public static StudentPersonalData Create(string name, string lastName, int age, string gender)
        {
            Validate(name, lastName, age, gender);
            return new StudentPersonalData(name, lastName, age, gender);
        }
        //validate method 
        public static void Validate(string name, string lastName, int age, string gender)
        {
            if (name.Equals(null))
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            if (lastName.Equals(null))
            {
                throw new ArgumentNullException("Last name cannot be null");
            }
            if (age.Equals(null))
            {
                throw new ArgumentNullException("Age cannot be null");
            }
            if (age <= 0)
            {
                throw new ArgumentException("Age cannot be less than zero");
            }
            if (gender.Equals(null))
            {
                throw new ArgumentNullException("Gender cannot be null");
            }
        }
    }
}
