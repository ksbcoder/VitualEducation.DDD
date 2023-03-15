using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class TeacherCreated : DomainEvent
    {
        public string TeacherID { get; set; }

        public TeacherCreated(string teacherID) : base("teacher.created")
        {
            TeacherID = teacherID;
        }
    }
}
