namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration
{
    public record RegistrationID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal RegistrationID(Guid id)
        {
            Value = id;
        }
        //create method
        public static RegistrationID Create(Guid id)
        {
            return new RegistrationID(id);
        }
        //implicit assignment
        public static implicit operator Guid(RegistrationID registrationID)
        {
            return registrationID.Value;
        }
    }
}
