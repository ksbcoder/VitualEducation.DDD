using VirtualEducation.DDD.Domain.Teacher.Entities;

namespace VirtualEducation.DDD.Domain.Teacher.Repositories
{
    public interface IClassroomRegistrationRepository
    {
        Task AddClassroomRegistration(ClassroomRegistrationTeacher classroomRegistration);
    }
}
