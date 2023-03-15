using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class AssessmentAdded : DomainEvent
    {
        public Assessment Assessment { get; private set; }

        public AssessmentAdded(Assessment assessment) : base("classroom.assessment.added")
        {
            Assessment = assessment;
        }
    }
}
