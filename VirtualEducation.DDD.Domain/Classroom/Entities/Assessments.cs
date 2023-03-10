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
        //references to other entities
        public Guid ClassroomID { get; private set; }
        [JsonIgnore]
        public virtual Classroom? Classroom { get; private set; }
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
        //set method for Classroom entity
        public void SetClassroom(Classroom classroom)
        {
            this.ClassroomID = classroom.ClassroomID;
            this.Classroom = classroom;
        }
    }
}
