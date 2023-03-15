namespace VirtualEducation.DDD.Domain.Classroom.Commands.Assessments
{
    public class AddAssessmentsCommand
    {
        public string ClassroomId { get; init; }
        public int Rating { get; init; }
        public string Feedback { get; init; }
    }
}
