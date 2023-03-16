using VirtualEducation.DDD.Domain.Classroom.Commands.Assessments;

namespace VirtualEducation.DDD.Tests.Builders.Classroom
{
    public class AddAssessmentCommandBuilder
    {
        private string _classroomId;
        private int _rating;
        private string _feedback;

        public AddAssessmentCommandBuilder WithClassroomId(string classroomId)
        {
            _classroomId = classroomId;
            return this;
        }

        public AddAssessmentCommandBuilder WithRating(int rating)
        {
            _rating = rating;
            return this;
        }

        public AddAssessmentCommandBuilder WithFeedback(string feedback)
        {
            _feedback = feedback;
            return this;
        }

        public AddAssessmentsCommand Build()
        {
            return new AddAssessmentsCommand(_classroomId, _rating, _feedback);
        }
    }
}
