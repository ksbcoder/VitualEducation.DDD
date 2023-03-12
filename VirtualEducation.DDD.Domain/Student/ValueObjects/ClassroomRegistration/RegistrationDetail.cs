namespace VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration
{
    public class RegistrationDetail
    {
        //variables
        public DateTime RegistratedAt { get; init; }


        //contructor
        public RegistrationDetail(DateTime registratedAt)
        {
            RegistratedAt = registratedAt;
        }

        //create method
        public static RegistrationDetail Create(DateTime registratedAt)
        {
            Validate(registratedAt);
            return new RegistrationDetail(registratedAt);
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
