namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses
{
    public class CourseID
    {
        public Guid ID { get; init; }
        public CourseID(Guid id)
        {
            ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static CourseID Of(Guid id)
        {
            return new CourseID(id);
        }

        //chaange any type in Guid
        public static implicit operator Guid(CourseID courseID)
        {
            return courseID.ID;
        }
    }
}
