namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Student
{
    public class StudentID
    {
        public Guid ID { get; init; }

        public StudentID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static StudentID Of(Guid id)
        {
            return new StudentID(id);
        }

        //chaange any type in Guid
        public static implicit operator Guid(StudentID studentID)
        {
            return studentID.ID;
        }
    }
}
