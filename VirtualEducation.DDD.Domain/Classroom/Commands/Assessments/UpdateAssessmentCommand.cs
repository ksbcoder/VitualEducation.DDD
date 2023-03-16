namespace VirtualEducation.DDD.Domain.Classroom.Commands.Assessments
{
    public class UpdateAssessmentCommand
    {
        public string ClassroomId { get; init; }
        public string AssessmentId { get; init; }
        public int Rating { get; init; }
        public string Feedback { get; init; }

        public UpdateAssessmentCommand(string classroomId, string assessmentId, int rating, string feedback)
        {
            ClassroomId = classroomId;
            AssessmentId = assessmentId;
            Rating = rating;
            Feedback = feedback;
        }
    }
}
