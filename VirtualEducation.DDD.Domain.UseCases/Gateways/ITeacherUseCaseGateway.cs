using VirtualEducation.DDD.Domain.Teacher.Commands.Account;
using VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.Commands.Teacher;

namespace VirtualEducation.DDD.Domain.UseCases.Gateways
{
    public interface ITeacherUseCaseGateway
    {
        Task<Teacher.Entities.Teacher> CreateTeacher(CreateTeacherCommand createTeacherCommand);

        Task<Teacher.Entities.Teacher> AddAcountToTeacher(TeacherAddAccountCommand addAccountCommand);

        Task<Teacher.Entities.Teacher> AddClassroomRegistrationToTeacher(
                       TeacherAddClassroomRegistrationCommand addClassroomRegistrationCommand);

        Task<Teacher.Entities.Teacher> UpdateEmail(TeacherUpdateEmailCommand updateEmailCommand);

        Task<Teacher.Entities.Teacher> GetTeacherById(string teacherId);
    }
}
