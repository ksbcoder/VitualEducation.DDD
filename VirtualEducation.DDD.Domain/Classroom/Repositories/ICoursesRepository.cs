using VirtualEducation.DDD.Domain.Classroom.Entities;

namespace VirtualEducation.DDD.Domain.Classroom.Repositories
{
    public interface ICoursesRepository
    {
        Task AddCourses(Courses courses);
    }
}
