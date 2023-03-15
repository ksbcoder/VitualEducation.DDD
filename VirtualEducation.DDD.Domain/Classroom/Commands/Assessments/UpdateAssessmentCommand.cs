namespace VirtualEducation.DDD.Domain.Classroom.Commands.Assessments
{
    public class UpdateAssessmentCommand
    {
        public string ClassroomId { get; init; }
        public string AssessmentId { get; init; }
        public int Rating { get; init; }
        public string Feedback { get; init; }
    }
}
