using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class TeacherAdded : DomainEvent
    {
        public TeacherID TeacherID { get; init; }
        public TeacherAdded(TeacherID teacherID) : base("classroom.teacher.added")
        {
            TeacherID = teacherID;
        }
    }
}
