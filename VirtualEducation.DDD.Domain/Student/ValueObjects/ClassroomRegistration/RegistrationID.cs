using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration
{
    public class RegistrationID : Identity
    {
        //contructor
        internal RegistrationID(Guid id) : base(id) { } //internal para que solo se pueda crear desde la misma capa


        //factory method: crea y devuelve una instancia usando el contructor
        public static RegistrationID Of(Guid id)
        {
            return new RegistrationID(id);
        }
    }
}
