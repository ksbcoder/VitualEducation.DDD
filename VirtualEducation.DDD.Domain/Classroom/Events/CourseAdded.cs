using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class CourseAdded : DomainEvent
    {
        public Course Course { get; init; }

        public CourseAdded(Course course) : base("classroom.course.added")
        {
            Course = course;
        }
    }
}
