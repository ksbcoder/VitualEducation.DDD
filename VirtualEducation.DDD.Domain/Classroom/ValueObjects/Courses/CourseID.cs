namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses
{
    public record CourseID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal CourseID(Guid id)
        {
            Value = id;
        }
        //create method
        public static CourseID Create(Guid id)
        {
            return new CourseID(id);
        }
        //implicit assignment
        public static implicit operator Guid(CourseID courseID)
        {
            return courseID.Value;
        }
    }
}
