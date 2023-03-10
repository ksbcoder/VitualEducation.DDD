namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher
{
    public record TeacherID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal TeacherID(Guid id)
        {
            Value = id;
        }
        //create method
        public static TeacherID Create(Guid id)
        {
            return new TeacherID(id);
        }
        //implicit assignment
        public static implicit operator Guid(TeacherID teacherID)
        {
            return teacherID.Value;
        }
    }
}
