namespace VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration
{
    public class StudentRegistrationDetail
    {
        //variables
        public DateTime RegistratedAt { get; init; }


        //contructor
        public StudentRegistrationDetail(DateTime registratedAt)
        {
            RegistratedAt = registratedAt;
        }

        //create method
        public static StudentRegistrationDetail Create(DateTime registratedAt)
        {
            Validate(registratedAt);
            return new StudentRegistrationDetail(registratedAt);
        }
        //validate method
        public static void Validate(DateTime registratedAt)
        {
            if (registratedAt.Equals(null))
            {
                throw new ArgumentNullException("Registration date cannot be null");
            }
        }
    }
}
