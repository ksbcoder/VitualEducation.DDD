using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Courses
    {
        //variables
        public Guid CourseID { get; init; }
        public CourseDetail CourseDetail { get; private set; }

        //references to other entities
        public Guid ClassroomID { get; private set; }
        [JsonIgnore]
        public virtual Classroom? Classroom { get; private set; }
        //contructor
        public Courses(Guid id)
        {
            this.CourseID = id;
        }
        //set method for course detail
        public void SetCouseDetail(CourseDetail couseDetail)
        {
            this.CourseDetail = couseDetail;
        }
        //set method for classroom entity
        public void SetClassroom(Classroom classroom)
        {
            this.ClassroomID = classroom.ClassroomID;
            this.Classroom = classroom;
        }
    }
}
