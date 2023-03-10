namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom
{
    public record ClassroomID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal ClassroomID(Guid id)
        {
            Value = id;
        }
        //create method
        public static ClassroomID Create(Guid id)
        {
            return new ClassroomID(id);
        }
        //implicit assignment
        public static implicit operator Guid(ClassroomID classroomID)
        {
            return classroomID.Value;
        }
    }
}
