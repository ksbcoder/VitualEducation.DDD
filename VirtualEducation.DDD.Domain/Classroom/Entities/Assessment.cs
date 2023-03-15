using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Assessment
    {
        //variables
        public Guid AssessmentID { get; init; }
        public Qualification Qualification { get; private set; }


        //contructors
        public Assessment(Guid assessmentID)
        {
            this.AssessmentID = assessmentID;
        }


        //set method for Qualification
        public void SetQualification(Qualification Qualification)
        {
            this.Qualification = Qualification;
        }
    }
}
