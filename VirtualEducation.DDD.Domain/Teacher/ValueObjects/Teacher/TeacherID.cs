using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher
{
    public class TeacherID
    {
        public Guid ID { get; init; }
        public TeacherID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static TeacherID Of(Guid id)
        {
            return new TeacherID(id);
        }

        //change any type to Guid
        public static implicit operator Guid(TeacherID teacherID)
        {
            return teacherID.ID;
        }
    }
}
