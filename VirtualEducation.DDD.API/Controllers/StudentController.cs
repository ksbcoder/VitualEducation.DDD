using Microsoft.AspNetCore.Mvc;
using VirtualEducation.DDD.Domain.Student.Commands.Account;
using VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.Commands.Student;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.UseCases.Gateways;

namespace VirtualEducation.DDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {


        private readonly IStudentUseCaseGateway _useCase;

        public StudentController(IStudentUseCaseGateway createStudentUseCase)
        {
            _useCase = createStudentUseCase;
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(string id)
        {
            var student = await _useCase.GetStudentById(id);
            return student;
        }

        [HttpPost]
        public async Task<Student> Post(CreateStudentCommand command)
        {
            var studentCreated = await _useCase.CreateStudent(command);
            return studentCreated;
        }

        [HttpPost("addAcount")]
        public async Task<Student> Add_Account_To_Student(AddAccountCommand command)
        {
            var studentWithAccount = await _useCase.AddAcountToStudent(command);
            return studentWithAccount;
        }

        [HttpPatch("updateAccountDetail")]
        public async Task<Student> Update_Account_Detail(UpdateAccountDetailCommand command)
        {
            var studentWithAccountUpdated = await _useCase.UpdateAccountDetail(command);
            return studentWithAccountUpdated;
        }

        [HttpPost("addClassroomRegistration")]
        public async Task<Student> Add_Classroom_Registration_To_Student
            (AddClassroomRegistrationCommand command)
        {
            var studentWithClassroomRegistration = await _useCase.AddClassroomRegistrationToStudent(command);
            return studentWithClassroomRegistration;
        }
    }
}
