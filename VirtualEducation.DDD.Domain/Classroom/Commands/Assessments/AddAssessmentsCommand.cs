namespace VirtualEducation.DDD.Domain.Classroom.Commands.Assessments
{
    public class AddAssessmentsCommand
    {
        public string ClassroomId { get; init; }
        public int Rating { get; init; }
        public string Feedback { get; init; }

        public AddAssessmentsCommand(string classroomId, int rating, string feedback)
        {
            ClassroomId = classroomId;
            Rating = rating;
            Feedback = feedback;
        }
    }
}
