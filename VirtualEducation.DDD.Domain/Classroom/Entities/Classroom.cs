using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Classroom
    {
        //variables
        public Guid ClassroomID { get; init; }
        public Preferences Preferences { get; private set; }
        //virtual navigation for entities
        [JsonIgnore]
        public virtual List<Courses>? Courses { get; private set; }
        public virtual List<Assessments>? Assessments { get; private set; }
        //constructor
        public Classroom(Guid id)
        {
            this.ClassroomID = id;
        }

        //set method for preferences
        public void SetPreferences(Preferences preferences)
        {
            this.Preferences = preferences;
        }

        //set method for courses
        public void SetCourses(List<Courses> courses)
        {
            this.Courses = courses;
        }
        //add method for courses
        public void AddCourse(Courses course)
        {
            this.Courses ??= new List<Courses>();
            this.Courses.Add(course);
        }
        //set method for assessments
        public void SetAssessments(List<Assessments> assessments)
        {
            this.Assessments = assessments;
        }
        //add method for assessments
        public void AddAssessment(Assessments assessment)
        {
            this.Assessments ??= new List<Assessments>();
            this.Assessments.Add(assessment);
        }
    }
}
