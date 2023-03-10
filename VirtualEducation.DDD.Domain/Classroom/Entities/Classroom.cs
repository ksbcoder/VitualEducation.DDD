using System.Text.Json.Serialization;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Classroom
    {
        //variables
        public Guid ClassroomID { get; init; }
        public Guid StudentID { get; private set; }
        public Guid TeacherID { get; private set; }
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

        //set method for student id
        public void SetStudentID(StudentID studentID)
        {
            this.StudentID = studentID;
        }
        //set method for teacher id
        public void SetTeacherID(TeacherID teacherID)
        {
            this.TeacherID = teacherID;
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
            course.SetClassroom(this);
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
            assessment.SetClassroom(this);
        }
    }
}
