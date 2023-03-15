using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class AssessmentToListAdded : DomainEvent
    {
        public Assessment Assessment { get; private set; }

        public AssessmentToListAdded(Assessment assessment) : base("classroom.assessmentToList.added")
        {
            Assessment = assessment;
        }
    }
}
