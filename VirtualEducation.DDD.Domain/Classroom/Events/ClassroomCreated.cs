using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class ClassroomCreated : DomainEvent
    {
        public string ClassroomID { get; set; }

        public ClassroomCreated(string classroomID) : base("classroom.created")
        {
            ClassroomID = classroomID;
        }
    }
}
