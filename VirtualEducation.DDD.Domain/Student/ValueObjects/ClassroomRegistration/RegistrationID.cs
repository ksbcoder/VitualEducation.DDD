using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration
{
    public class StudentRegistrationID : Identity
    {
        //contructor
        internal StudentRegistrationID(Guid id) : base(id) { } //internal para que solo se pueda crear desde la misma capa


        //factory method: crea y devuelve una instancia usando el contructor
        public static StudentRegistrationID Of(Guid id)
        {
            return new StudentRegistrationID(id);
        }
    }
}
