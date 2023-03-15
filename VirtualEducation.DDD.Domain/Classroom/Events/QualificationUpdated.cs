using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class QualificationUpdated : DomainEvent
    {
        public string AssessmentId { get; set; }
        public Qualification Qualification { get; set; }
        public QualificationUpdated(Qualification qualification, string assessmentId) : base("classroom.assessment.qualification.updated")
        {
            AssessmentId = assessmentId; 
            Qualification = qualification;
        }
    }
}
