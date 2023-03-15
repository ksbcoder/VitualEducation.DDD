using VirtualEducation.DDD.Domain.Classroom.Events;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Entities.Rebuild
{
    public class ClassroomRebuild
    {
        public Classroom CreateAggregate(List<DomainEvent> ev, ClassroomID classroomID)
        {
            Classroom classroom = new(classroomID);
            ev.ForEach(evento =>
            {
                switch (evento)
                {
                    //classroom
                    case PreferencesAdded preferencesAdded:
                        classroom.SetPreferencesAggregate(preferencesAdded.Preferences);
                        break;
                    //courses
                    case CourseAdded courseAdded:
                        classroom.SetCoursesAggregate(courseAdded.Course);
                        break;
                    case CourseDetailAdded courseDetailAdded:
                        classroom.SetDetailToCourseAggregate(courseDetailAdded.CourseDetail);
                        break;
                    //assessments
                    case AssessmentAdded assessmentAdded:
                        classroom.SetAssessmentsAggregate(assessmentAdded.Assessment);
                        break;
                    case AssessmentQualificationAdded assessmentQualificationAdded:
                        classroom.SetQualificationAggregate(assessmentQualificationAdded.Qualification);
                        break;
                    case QualificationUpdated qualificationUpdated:
                        Classroom.SetQualificationUpdatedAggregate(
                            classroom.Assessments,
                            qualificationUpdated.Qualification,
                            qualificationUpdated.AssessmentId
                            );
                        break;
                    //student aggregate
                    case StudentAdded studentAdded:
                        classroom.SetStudentAggregate(studentAdded.StudentID);
                        break;
                    //teacher aggregate
                    case TeacherAdded teacherAdded:
                        classroom.SetTeacherAggregate(teacherAdded.TeacherID);
                        break;
                }
            });
            return classroom;
        }
    }
}
