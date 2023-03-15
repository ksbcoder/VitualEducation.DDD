using VirtualEducation.DDD.Domain.Classroom.Commands.Assessments;
using VirtualEducation.DDD.Domain.Classroom.Commands.Classroom;
using VirtualEducation.DDD.Domain.Classroom.Commands.Courses;
using VirtualEducation.DDD.Domain.Classroom.Commands.Student;

namespace VirtualEducation.DDD.Domain.UseCases.Gateways
{
    public interface IClassroomUseCaseGateway
    {
        //classroom agregate
        Task<Classroom.Entities.Classroom> CreateClassroom(CreateClassroomCommand createClassroomCommand);
        Task<Classroom.Entities.Classroom> AddCoursesToClassroom(AddCoursesCommand addCoursesCommand);
        Task<Classroom.Entities.Classroom> AddAssessmentsToClassroom(AddAssessmentsCommand addAssessmentsCommand);
        Task<Classroom.Entities.Classroom> UpdateAssessment(UpdateAssessmentCommand updateAssessmentCommand);
        Task<Classroom.Entities.Classroom> GetClassroomById(string classroomId);
        //student aggregate
        Task<Classroom.Entities.Classroom> AddStudentsToClassroom(ClassroomAddStudentsCommand classroomAddStudentsCommand);
    }
}
