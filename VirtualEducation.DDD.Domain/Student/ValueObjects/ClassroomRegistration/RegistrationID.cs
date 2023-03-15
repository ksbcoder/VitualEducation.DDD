namespace VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration
{
    public class StudentRegistrationID
    {
        public Guid ID { get; init; }
        public StudentRegistrationID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static StudentRegistrationID Of(Guid id)
        {
            return new StudentRegistrationID(id);
        }

        //change any type in Guid
        public static implicit operator Guid(StudentRegistrationID studentRegistrationID)
        {
            return studentRegistrationID.ID;
        }
    }
}
