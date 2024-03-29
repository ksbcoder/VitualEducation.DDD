﻿using VirtualEducation.DDD.Domain.Classroom.Events;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses;
using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Classroom.Entities
{
    public class Classroom : AggregateEvent
    {
        //variables
        public ClassroomID ClassroomID { get; init; }
        public Preferences Preferences { get; private set; }
        //virtual navigation for entities
        public virtual StudentID StudentID { get; private set; }
        public virtual TeacherID TeacherID { get; private set; }
        public virtual List<Course>? Courses { get; private set; }
        public virtual List<Assessment>? Assessments { get; private set; }


        //constructor
        public Classroom(ClassroomID classroomID)
        {
            this.ClassroomID = classroomID;
        }

        #region Metodos del agregado como manejador de eventos
        //Classroom
        public void SetClassroomID(ClassroomID classroomID)
        {
            AppendChange(new ClassroomCreated(classroomID.ToString()));
        }
        public void SetPreferences(Preferences preferences)
        {
            AppendChange(new PreferencesAdded(preferences));
        }
        //Courses
        public void SetCourseToClassroom(Course course)
        {
            AppendChange(new CourseAdded(course));
        }
        public void SetDetailToCourse(CourseDetail courseDetail)
        {
            AppendChange(new CourseDetailAdded(courseDetail));
        }
        //Assessments
        public void SetAssessmentToClassroom(Assessment assessment)
        {
            AppendChange(new AssessmentAdded(assessment));
        }
        public void SetQualificationToAssessment(Qualification qualification)
        {
            AppendChange(new AssessmentQualificationAdded(qualification));
        }
        public void SetQualificationUpdatedToAssessment(Qualification qualification, string assessmentId)
        {
            AppendChange(new QualificationUpdated(qualification, assessmentId));
        }
        //student
        public void SetStudent(StudentID studentID)
        {
            AppendChange(new StudentAdded(studentID));
        }
        //teacher
        public void SetTeacher(TeacherID teacherID)
        {
            AppendChange(new TeacherAdded(teacherID));
        }
        #endregion

        #region Metodos del agregado como manejador de eventos
        //Classroom
        public void SetPreferencesAggregate(Preferences preferences)
        {
            this.Preferences = preferences;
        }
        //Courses
        public void SetCoursesAggregate(Course course)
        {
            this.Courses ??= new();
            this.Courses.Add(course);
        }
        public void SetDetailToCourseAggregate(CourseDetail courseDetail)
        {
            this.Courses.Last().SetCouseDetail(courseDetail);
        }
        //Assessments
        public void SetAssessmentsAggregate(Assessment assessment)
        {
            this.Assessments ??= new();
            this.Assessments.Add(assessment);
        }
        public void SetQualificationAggregate(Qualification qualification)
        {
            this.Assessments.Last().SetQualification(qualification);
        }
        public static void SetQualificationUpdatedAggregate(
            List<Assessment> assessments,
            Qualification qualification,
            string assessmentId
            )
        {
            foreach (var ass in assessments)
            {
                if (ass.AssessmentID.Equals(Guid.Parse(assessmentId)))
                {
                    ass.SetQualification(qualification);
                }
            }
        }
        //student
        public void SetStudentAggregate(StudentID studentID)
        {
            this.StudentID = studentID;
        }
        //teacher
        public void SetTeacherAggregate(TeacherID teacherID)
        {
            this.TeacherID = teacherID;
        }
        #endregion

    }
}
