using VirtualEducation.DDD.Domain.Student.Entities;

namespace VirtualEducation.DDD.Domain.Student.Repositories
{
    public interface IClassroomRegistrationRepository
    {
        Task AddClassroomRegistration(ClassroomRegistrationStudent classroomRegistration);
    }
}
