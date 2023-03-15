using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class AssessmentQualificationAdded : DomainEvent
    {
        public Qualification Qualification { get; private set; }

        public AssessmentQualificationAdded(Qualification qualification) : base("classroom.assessments.qualification.added")
        {
            Qualification = qualification;
        }
    }
}
