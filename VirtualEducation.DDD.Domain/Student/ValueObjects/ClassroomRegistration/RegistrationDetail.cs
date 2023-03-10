namespace VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration
{
    public record RegistrationDetail
    {
        //variables
        public DateTime RegistratedAt { get; init; }
        //contructor
        internal RegistrationDetail(DateTime registratedAt)
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
