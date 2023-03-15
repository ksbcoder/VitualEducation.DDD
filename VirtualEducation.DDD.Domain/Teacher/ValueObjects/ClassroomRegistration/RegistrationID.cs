namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration
{
    public class TeacherRegistrationID
    {
        public Guid ID { get; init; }
        public TeacherRegistrationID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static TeacherRegistrationID Of(Guid id)
        {
            return new TeacherRegistrationID(id);
        }

        //change any type to Guid
        public static implicit operator Guid(TeacherRegistrationID teacherRegistrationID)
        {
            return teacherRegistrationID.ID;
        }
    }
}
