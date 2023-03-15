using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class CourseDetailAdded : DomainEvent
    {
        public CourseDetail CourseDetail { get; set; }

        public CourseDetailAdded(CourseDetail courseDetail) : base("classroom.courses.detail.added")
        {
            CourseDetail = courseDetail;
        }
    }
}
