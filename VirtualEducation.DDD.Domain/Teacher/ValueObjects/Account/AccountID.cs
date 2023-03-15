namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public class TeacherAccountID
    {
        public Guid ID { get; init; }
        //contructor
        public TeacherAccountID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static TeacherAccountID Of(Guid id)
        {
            return new TeacherAccountID(id);
        }

        //change any type in Guid
        public static implicit operator Guid(TeacherAccountID teacherAccountID)
        {
            return teacherAccountID.ID;
        }
    }
}
