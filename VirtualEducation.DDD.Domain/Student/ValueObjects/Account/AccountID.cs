namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public class StudentAccountID
    {
        public Guid ID { get; init; }

        public StudentAccountID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static StudentAccountID Of(Guid id)
        {
            return new StudentAccountID(id);
        }

        //change any type in Guid
        public static implicit operator Guid(StudentAccountID studentAccountID)
        {
            return studentAccountID.ID;
        }
    }
}
