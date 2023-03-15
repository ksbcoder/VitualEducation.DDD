using Microsoft.AspNetCore.Mvc;
using VirtualEducation.DDD.Domain.Teacher.Commands.Account;
using VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.Commands.Teacher;
using VirtualEducation.DDD.Domain.Teacher.Entities;
using VirtualEducation.DDD.Domain.UseCases.Gateways;

namespace VirtualEducation.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherUseCaseGateway _useCase;
        public TeacherController(ITeacherUseCaseGateway teacherUseCaseGateway)
        {
            _useCase = teacherUseCaseGateway;
        }

        [HttpGet("{id}")]
        public async Task<Teacher> GetTeacherById(string id)
        {
            var teacher = await _useCase.GetTeacherById(id);
            return teacher;
        }

        [HttpPost]
        public async Task<Teacher> CreateTeacher(CreateTeacherCommand command)
        {
            var teacherCreated = await _useCase.CreateTeacher(command);
            return teacherCreated;
        }

        [HttpPost("addAcount")]
        public async Task<Teacher> Add_Account_To_Teacher(TeacherAddAccountCommand command)
        {
            var teacherWithAccount = await _useCase.AddAcountToTeacher(command);
            return teacherWithAccount;
        }

        [HttpPatch("updateEmail")]
        public async Task<Teacher> Update_Email(TeacherUpdateEmailCommand command)
        {
            var teacherWithEmailUpdated = await _useCase.UpdateEmail(command);
            return teacherWithEmailUpdated;
        }

        [HttpPost("addClassroomRegistration")]
        public async Task<Teacher> Add_Classroom_Registration_To_Teacher
            (TeacherAddClassroomRegistrationCommand command)
        {
            var teacherWithClassroomRegistration = await _useCase.AddClassroomRegistrationToTeacher(command);
            return teacherWithClassroomRegistration;
        }
    }
}
