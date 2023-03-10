namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Student
{
    public record StudentID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal StudentID(Guid id)
        {
            Value = id;
        }
        //create method
        public static StudentID Create(Guid id)
        {
            return new StudentID(id);
        }
        //implicit assignment
        public static implicit operator Guid(StudentID studentID)
        {
            return studentID.Value;
        }
    }
}
