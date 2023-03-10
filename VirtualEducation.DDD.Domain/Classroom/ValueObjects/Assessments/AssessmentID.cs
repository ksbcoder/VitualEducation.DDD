namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment
{
    public record AssessmentID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal AssessmentID(Guid id)
        {
            Value = id;
        }
        //create method
        public static AssessmentID Create(Guid id)
        {
            return new AssessmentID(id);
        }
        //implicit assignment
        public static implicit operator Guid(AssessmentID assessmentID)
        {
            return assessmentID.Value;
        }
    }
}
