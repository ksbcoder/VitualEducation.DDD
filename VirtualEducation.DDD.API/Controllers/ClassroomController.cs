﻿using Microsoft.AspNetCore.Mvc;
using VirtualEducation.DDD.Domain.Classroom.Commands.Assessments;
using VirtualEducation.DDD.Domain.Classroom.Commands.Classroom;
using VirtualEducation.DDD.Domain.Classroom.Commands.Courses;
using VirtualEducation.DDD.Domain.Classroom.Commands.Student;
using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.UseCases.Gateways;

namespace VirtualEducation.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomUseCaseGateway _useCase;
        public ClassroomController(IClassroomUseCaseGateway classroomUseCaseGateway)
        {
            _useCase = classroomUseCaseGateway;
        }

        [HttpGet("{id}")]
        public async Task<Classroom> GetClassroomById(string id)
        {
            var classroom = await _useCase.GetClassroomById(id);
            return classroom;
        }

        [HttpPost]
        public async Task<Classroom> CreateClassroom(CreateClassroomCommand command)
        {
            var classroomCreated = await _useCase.CreateClassroom(command);
            return classroomCreated;
        }

        [HttpPost("addCourses")]
        public async Task<Classroom> Add_Courses_To_Classroom(AddCoursesCommand command)
        {
            var classroomWithCourses = await _useCase.AddCoursesToClassroom(command);
            return classroomWithCourses;
        }

        [HttpPost("addAssessments")]
        public async Task<Classroom> Add_Assessments_To_Classroom(AddAssessmentsCommand command)
        {
            var classroomWithAssessments = await _useCase.AddAssessmentsToClassroom(command);
            return classroomWithAssessments;
        }

        [HttpPatch("updateAssessment")]
        public async Task<Classroom> Update_Assessment(UpdateAssessmentCommand command)
        {
            var classroomWithAssessments = await _useCase.UpdateAssessment(command);
            return classroomWithAssessments;
        }

        [HttpPost("addStudents")]
        public async Task<Classroom> Add_Students_To_Classroom(ClassroomAddStudentsCommand command)
        {
            var classroomWithStudents = await _useCase.AddStudentsToClassroom(command);
            return classroomWithStudents;
        }

        //[HttpPost("addTeachers")]
        //public async Task<Classroom> Add_Teachers_To_Classroom(ClassroomAddTeachersCommand command)
        //{
        //    var classroomWithTeachers = await _useCase.AddTeachersToClassroom(command);
        //    return classroomWithTeachers;
        //}
    }
}
