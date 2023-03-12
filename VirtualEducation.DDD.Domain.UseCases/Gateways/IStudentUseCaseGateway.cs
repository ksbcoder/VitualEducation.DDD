using VirtualEducation.DDD.Domain.Student.Commands.Account;
using VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.Commands.Student;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.UseCases.Gateways
{
    public interface IStudentUseCaseGateway
    {
        Task<Student.Entities.Student> CreateStudent(CreateStudentCommand createStudentCommand);

        Task<Student.Entities.Student> AddAcountToStudent(AddAccountCommand addAccountCommand);

        Task<Student.Entities.Student> AddClassroomRegistrationToStudent(
            AddClassroomRegistrationCommand addClassroomRegistrationCommand);

        Task<Student.Entities.Student> UpdateAccountDetail(UpdateAccountDetailCommand updateAccountDetailCommand);

        Task<Student.Entities.Student> GetStudentById(string studentId);
    }
}
