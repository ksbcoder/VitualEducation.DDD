using VirtualEducation.DDD.Domain.Student.Commands.Account;
using VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.Commands.Student;

namespace VirtualEducation.DDD.Domain.UseCases.Gateways
{
    public interface IStudentUseCaseGateway
    {
        Task<Student.Entities.Student> CreateStudent(CreateStudentCommand createStudentCommand);

        Task<Student.Entities.Student> AddAcountToStudent(StudentAddAccountCommand addAccountCommand);

        Task<Student.Entities.Student> AddClassroomRegistrationToStudent(
            StudentAddClassroomRegistrationCommand addClassroomRegistrationCommand);

        Task<Student.Entities.Student> UpdateAccountDetail(StudentUpdateAccountDetailCommand updateAccountDetailCommand);

        Task<Student.Entities.Student> GetStudentById(string studentId);
    }
}
