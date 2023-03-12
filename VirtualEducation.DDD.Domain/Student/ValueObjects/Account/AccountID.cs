using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public class StudentAccountID : Identity
    {
        //contructor
        internal StudentAccountID(Guid id) : base(id) { } //internal para que solo se pueda crear desde la misma capa



        //factory method: crea y devuelve una instancia usando el contructor
        public static StudentAccountID Of(Guid id)
        {
            return new StudentAccountID(id);
        }
    }
}
