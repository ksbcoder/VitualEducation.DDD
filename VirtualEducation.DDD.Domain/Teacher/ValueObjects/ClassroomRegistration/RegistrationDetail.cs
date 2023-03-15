namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration
{
    public class TeacherRegistrationDetail
    {
        //variables
        public DateTime RegistratedAt { get; init; }


        //contructor
        public TeacherRegistrationDetail(DateTime registratedAt)
        {
            RegistratedAt = registratedAt;
        }


        //create method
        public static TeacherRegistrationDetail Create(DateTime registratedAt)
        {
            Validate(registratedAt);
            return new TeacherRegistrationDetail(registratedAt);
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
