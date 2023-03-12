using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration
{
    public class TeacherRegistrationID : Identity
    {
        //contructor
        internal TeacherRegistrationID(Guid id) : base(id) { } //internal para que solo se pueda crear desde la misma capa


        //factory method: crea y devuelve una instancia usando el contructor
        public static TeacherRegistrationID Of(Guid id)
        {
            return new TeacherRegistrationID(id);
        }
    }
}
