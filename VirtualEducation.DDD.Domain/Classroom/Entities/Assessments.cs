using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Assessments
    {
        //variables
        public Guid AssessmentID { get; init; }
        public Qualification Qualification { get; private set; }


        //contructor
        public Assessments(Guid id) 
        { 
            this.AssessmentID = id; 
        }
        //set method for Qualification
        public void SetQualification(Qualification Qualification)
        {
            this.Qualification = Qualification;
        }
    }
}
