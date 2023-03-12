using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public class TeacherAccountID : Identity
    {
        //contructor
        internal TeacherAccountID(Guid id) : base(id) { } //internal para que solo se pueda crear desde la misma capa



        //factory method: crea y devuelve una instancia usando el contructor
        public static TeacherAccountID Of(Guid id)
        {
            return new TeacherAccountID(id);
        }
    }
}
