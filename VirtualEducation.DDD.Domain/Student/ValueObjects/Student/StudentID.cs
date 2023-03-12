using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Student
{
    public class StudentID : Identity
    {
        //contructor
        public StudentID(Guid id) : base(id) { }


        //factory method: crea y devuelve una instancia usando el contructor
        public static StudentID Of(Guid id)
        {
            return new StudentID(id);
        }
    }
}
