namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment
{
    public class AssessmentID
    {
        public Guid ID { get; init; }
        public AssessmentID(Guid id)
        {
            this.ID = id;
        }

        //factory method: crea y devuelve una instancia usando el contructor
        public static AssessmentID Of(Guid id)
        {
            return new AssessmentID(id);
        }

        //change any type to Guid
        public static implicit operator Guid(AssessmentID assessmentID)
        {
            return assessmentID.ID;
        }
    }
}
