using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher
{
    public class TeacherID : Identity
    {
        //constructor
        internal TeacherID(Guid id) : base(id) { }


        //factory method: crea y devuelve una instancia usando el contructor
        public static TeacherID Of(Guid id)
        {
            return new TeacherID(id);
        }
    }
}
