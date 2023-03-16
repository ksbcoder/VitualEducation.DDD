using VirtualEducation.DDD.Domain.Classroom.Commands.Assessments;

namespace VirtualEducation.DDD.Tests.Builders.Classroom
{
    public class UpdateAssessmentCommandBuilder
    {
        private string _classroomId;
        private string _assessmentId;
        private int _rating;
        private string _feedback;
        public UpdateAssessmentCommandBuilder WithClassroomId(string classroomId)
        {
            _classroomId = classroomId;
            return this;
        }
        public UpdateAssessmentCommandBuilder WithAssessmentId(string assessmentId)
        {
            _assessmentId = assessmentId;
            return this;
        }
        public UpdateAssessmentCommandBuilder WithRating(int rating)
        {
            _rating = rating;
            return this;
        }
        public UpdateAssessmentCommandBuilder WithFeedback(string feedback)
        {
            _feedback = feedback;
            return this;
        }
        public UpdateAssessmentCommand Build()
        {
            return new UpdateAssessmentCommand(_classroomId, _assessmentId, _rating, _feedback);
        }
    }
}
