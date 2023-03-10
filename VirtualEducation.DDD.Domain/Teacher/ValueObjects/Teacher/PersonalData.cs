namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher
{
    public record PersonalData
    {
        //variables
        public string Name { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
        public string Gender { get; init; }
        //constructor
        internal PersonalData(string name, string lastName, int age, string gender)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
        //create method
        public static PersonalData Create(string name, string lastName, int age, string gender)
        {
             Validate(name, lastName, age, gender);
            return new PersonalData(name, lastName, age, gender);
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
            if (age.Equals(null) || age <= 0)
            {
                throw new ArgumentNullException("Age cannot be null or less than zero");
            }
            if (gender.Equals(null))
            {
                throw new ArgumentNullException("Gender cannot be null");
            }
        }
    }
}
