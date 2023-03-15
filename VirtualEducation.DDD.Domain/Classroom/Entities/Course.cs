using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Course
    {
        //variables
        public Guid CourseID { get; init; }
        public CourseDetail CourseDetail { get; private set; }

        //contructor
        public Course(Guid courseID)
        {
            this.CourseID = courseID;
        }

        //set method for course detail
        public void SetCouseDetail(CourseDetail couseDetail)
        {
            this.CourseDetail = couseDetail;
        }
    }
}
