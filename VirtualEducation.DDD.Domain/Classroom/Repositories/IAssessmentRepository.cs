using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;

namespace VirtualEducation.DDD.Domain.Classroom.Repositories
{
    public interface IAssessmentRepository
    {
        Task AddAssessments(Assessments assessments);
        Task DeleteAssessment(AssessmentID assessmentID);
    }
}
