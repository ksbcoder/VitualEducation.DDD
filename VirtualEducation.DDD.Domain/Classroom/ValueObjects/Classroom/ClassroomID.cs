namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom
{
    public class ClassroomID
    {
        public Guid ID { get; init; }
        public ClassroomID(Guid id)
        {
            ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static ClassroomID Of(Guid id)
        {
            return new ClassroomID(id);
        }

        //chaange any type in Guid
        public static implicit operator Guid(ClassroomID classroomID)
        {
            return classroomID.ID;
        }
    }
}
